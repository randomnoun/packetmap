using System;
using System.IO;
using System.Runtime.InteropServices; // DllImport
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.ComponentModel;
using System.Threading;

using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;

// perf notes: if time is set to fire every 5secs, this app uses 1.2% of CPU 
// (on my laptop, at least, with not too many processes or windows running)

namespace Timetube {

    class ProcessDetails {
        public int id;
        public string processName;
        public string processExe;
        public string dimensions;
        public string mainWindowTitle;

        public override String ToString() {
            return String.Format("{0}\t{1}\t{2}\t{3}\t{4}", id, processName, processExe, dimensions, mainWindowTitle);
        }
        public override bool Equals(Object other) {
            if (!(other is ProcessDetails)) { return false; }
            ProcessDetails o = (ProcessDetails) other;
            return (o.processName.Equals(processName) &&
                o.processExe.Equals(processExe) &&  // -- we could comment this out
                o.dimensions.Equals(dimensions) &&
                o.mainWindowTitle.Equals(mainWindowTitle));
        }
        public override int GetHashCode() {
            return id;
        }
    }

    class WindowDetails {
        public int pid;
        public int hwnd;
        public string dimensions;  // @TODO use rc
        public string module;
        public string title;
        // public string path;
        public int iconId;


        public override string ToString() {
            return String.Format("{0} {1} [{2}] {3} '{4}' '{5}'", pid, hwnd, iconId, dimensions, module, title);
        }
        public override bool Equals(object other) {
            if (!(other is WindowDetails)) { return false; }
            WindowDetails o = (WindowDetails) other;
            return (o.pid == pid && o.hwnd == hwnd &&
                o.dimensions.Equals(dimensions) &&
                ((o.module==null && module==null) || o.module.Equals(module)) &
                ((o.title==null && title==null) || o.title.Equals(title)));
        }
        public override int GetHashCode() {
            return pid + hwnd;
        }
    }


    class Timetube {
        static Hashtable processMap = new Hashtable();
        static Hashtable windowMap = new Hashtable();
        static Hashtable iconMap = new Hashtable();

        public static List<String> eventList = new List<String>();
        public static List<int> hwndOrder = new List<int>();

        static bool   working = false;
        public static int iconNum = 0;

        public static Hashtable getProcessMap() {
            Hashtable newMap = new Hashtable();
            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcesses();
            for (int i = 0; i < myProcesses.Length; i++) {
                ProcessDetails pd = new ProcessDetails();
                newMap.Add(myProcesses[i].Id, pd);
                System.Diagnostics.Process p = myProcesses[i];
                pd.id = myProcesses[i].Id;
                // cache process name ?
                pd.processName = p.ProcessName;
                if (!processMap.ContainsKey(pd.id)) {
                    try {
                        pd.processExe = p.MainModule.FileName;
                    } catch (System.ComponentModel.Win32Exception we) {
                        pd.processExe = "";
                    }
                } else {
                    // just copy the exe across from previous lookup to save time
                    pd.processExe = ((ProcessDetails)processMap[pd.id]).processExe;
                }
                
                pd.dimensions = "";
                pd.mainWindowTitle = "";
                

                // this takes 2 secs to iterate; replaced with GetWindowText() below
                // pd.mainWindowTitle = p.MainWindowTitle;  

                // this takes 0.78 secs; replaced with window enumeration below
                /*
                try {
                    Win32.RECT rc = new Win32.RECT();
                    IntPtr hwnd = p.MainWindowHandle;
                    Win32.GetWindowRect(hwnd, ref rc);
                    pd.dimensions = String.Format("({0},{1})-({2},{3})", rc.left, rc.top, rc.right, rc.bottom);
                } catch (System.ComponentModel.Win32Exception we) {
                }
                 */

                // this takes 2 seconds to process for all processes on my laptop (arg!);
                // replaced with WMI + getWindowModuleFilename() below
                /*
                try {
                    System.Diagnostics.ProcessModuleCollection pcm = p.Modules;
                    if (pcm.Count > 0) {
                        System.Diagnostics.ProcessModule pm = pcm[0];
                        pd.processExe = pm.FileName;
                    }
                } catch (System.ComponentModel.Win32Exception we) {
                } catch (InvalidOperationException ioe) {
                    // occurs if process is closed whilst process list is being iterated
                }
                */
                // Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", myProcesses[i].Id, processName, processExe, dimensions, p.MainWindowTitle);
            }
            return newMap;
        }

        public static void mergeProcessMap(StreamWriter sw, Hashtable newMap) {
            foreach (int pid in processMap.Keys) {
                if (!newMap.ContainsKey(pid)) {
                    sw.WriteLine("P - " + pid);
                } else if (!newMap[pid].Equals(processMap[pid])) {
                    sw.WriteLine("P ! " + newMap[pid].ToString());
                }
            }
            foreach (int pid in newMap.Keys) {
                if (!processMap.ContainsKey(pid)) {
                    sw.WriteLine("P + " + newMap[pid].ToString());
                }
            }
            processMap = newMap;
        }

        public static void mergeWindowMap(StreamWriter sw, Hashtable newMap) {
            foreach (string handle in windowMap.Keys) {
                if (!newMap.ContainsKey(handle)) {
                    sw.WriteLine("W - " + handle);
                } else if (!newMap[handle].Equals(windowMap[handle])) {
                    sw.WriteLine("W ! " + newMap[handle].ToString());
                }
            }
            foreach (string handle in newMap.Keys) {
                if (!windowMap.ContainsKey(handle)) {
                    sw.WriteLine("W + " + newMap[handle].ToString());
                }
            }
            windowMap = newMap;
        }

        public static void mergeHwndOrder(StreamWriter sw, List<int> newHwndOrder) {
            // work out the bottom-most window that's unchanged
            int unchanged = hwndOrder.Count-1;
            int scan = newHwndOrder.Count-1;
            while (unchanged > 0 && scan > 0 && (hwndOrder[unchanged] == newHwndOrder[scan])) {
                unchanged--;
                scan--;
            }
            // List from unchanged->hwndOrder.Count == scan->newHwndOrder.Count, just display 0->scan
            if (scan > 0) {
                sw.Write("WO ! ");
                for (int i = 0; i <= scan; i++) {
                    sw.Write(newHwndOrder[i] + " ");
                }
                sw.WriteLine();
            }
            hwndOrder = newHwndOrder;
        }

        public static Hashtable getWindowMap(List<int> newHwndOrder) {
            Hashtable newMap = new Hashtable();
            Win32.RECT rc = new Win32.RECT();
            IntPtr hwnd = Win32.GetDesktopWindow();
            hwnd = Win32.GetTopWindow(hwnd);  // get first window

            int pid;
            if (IntPtr.Zero == hwnd) { return null; }
            StringBuilder title = new StringBuilder(1000);
            StringBuilder module = new StringBuilder(1000);
            //StringBuilder path = new StringBuilder(1000);
            while (IntPtr.Zero != hwnd) {
                IntPtr threadId = Win32.GetWindowThreadProcessId(hwnd, out pid);
                if (Win32.IsWindowVisible(hwnd) != 0) {
                    newHwndOrder.Add(hwnd.ToInt32());
                    IntPtr processHwnd = Win32.OpenProcess(0, false, pid);  // pid ?
                    
                    //path.Length = 0;
                    module.Length = 0;
                    title.Length = 0;
                    // Win32.GetModuleFileName(processHwnd, path, 1000); // just gets this .exe's filename
                    Win32.GetWindowModuleFileName(hwnd, module, 1000);   // seems to be empty most of the time ?
                    Win32.GetWindowText(hwnd, title, 1000);
                    Win32.GetWindowRect(hwnd, ref rc);

                    // Console.WriteLine("{0} {1} ({2},{3})-({4},{5}) '{6}' '{7}'", pid, hwnd.ToInt32(), rc.left, rc.top, rc.right, rc.bottom, module, title);
                    WindowDetails wd = new WindowDetails();
                    wd.pid = pid;
                    wd.hwnd = hwnd.ToInt32();
                    wd.dimensions = String.Format("({0},{1})-({2},{3})", rc.left, rc.top, rc.right, rc.bottom);
                    wd.title = title.ToString();
                    wd.module = module.ToString();
                    // wd.path = path.ToString();
                    newMap.Add(wd.pid + ":" + wd.hwnd, wd);

                    /* skip icon saving; check http://www.kennyandkarin.com/Kenny/CodeCorner/Tools/IconBrowser/
                     * later for some ideas
                     * - adderss space problems ?
                    IntPtr hIcon = (IntPtr)Win32.SendMessage(hwnd, 0x007f, 0, 0);   // WM_GETICON
                    if (IntPtr.Zero != hIcon) {
                        Icon ic = Icon.FromHandle(hwnd);
                        Bitmap b = ic.ToBitmap();
                        ic.Dispose();
                        FileStream fs = new FileStream(String.Format(@"c:\temp\icons\{0}.ico", iconNum), FileMode.Create, FileAccess.Write);
                        // ic.Save(fs);
                        b.Save(fs, System.Drawing.Imaging.ImageFormat.Icon);
                        fs.Close();
                        iconNum++;
                    }
                     */

                    // other code from  http://www.codeproject.com/csharp/taskbarsorter.asp 
                    UInt32 hIcon = 0;
                    if (hIcon == 0) hIcon = Win32.SendMessage(hwnd, WM.GETICON, ICON.SMALL2, 0);
                    if (hIcon == 0) hIcon = Win32.GetClassLong(hwnd, GCL.HICONSM);
                    if (hIcon == 0) hIcon = Win32.GetClassLong(hwnd, GCL.HICON);
                    if (hIcon != 0) {
                        Bitmap bitmap = null;
                        try {
                            Int32 hIcon2 = unchecked((Int32)hIcon);
                            bitmap = Bitmap.FromHicon(new IntPtr(hIcon2));
                        } catch (ArgumentException) { continue; }
                        if (bitmap != null) {
                            // hash bitmap; if it's new, save it.
                            
                            
                            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                            byte[] bytes = new byte[bitmap.Width * bitmap.Height * 3];
                            int byteIndex = 0;
                            int stride = data.Stride;
                            System.IntPtr Scan0 = data.Scan0;
                            // convert to flattened format to prepare for hash
                            unsafe {
                                byte nVal;
                                byte* p = (byte*)(void*)Scan0;
                                int nOffset = stride - bitmap.Width * 3;
                                int nWidth = bitmap.Width * 3;
                                for (int y = 0; y < bitmap.Height; ++y) {
                                    for (int x = 0; x < nWidth; ++x) {
                                        nVal = (byte)(p[0]);
                                        bytes[byteIndex++] = (byte)(nVal);

                                        //if (nVal < 0) nVal = 0;
                                        //if (nVal > 255) nVal = 255;
                                        //p[0] = (byte)nVal;
                                        ++p;
                                    }
                                    p += nOffset;
                                }
                            }
                            bitmap.UnlockBits(data);

                            MD5 md = new MD5CryptoServiceProvider();
                            string hash = Convert.ToBase64String(md.ComputeHash(bytes));

                            // (hashWithSaltBytes);
                            if (iconMap.ContainsKey(hash)) {
                                // exists
                                wd.iconId = (int) iconMap[hash];
                            } else {
                                wd.iconId = iconNum;
                                iconMap[hash] = iconNum;
                                FileStream fs = new FileStream(String.Format(@"c:\temp\icons\{0}.png", iconNum), FileMode.Create, FileAccess.Write);
                                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                                bitmap.Dispose();
                                iconNum++;
                            }
                        }
                    }



                }
                hwnd = Win32.GetNextWindow(hwnd, Win32.GW_HWNDNEXT);
            }
            return newMap;
        }

        [MTAThread]
        public static int Main(string[] args) {

            // add timer
            System.Timers.Timer t;
            t = new System.Timers.Timer(5 * 1000);
            t.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            t.Start();


            WmiEventHandler myHandler = new WmiEventHandler();
            EventArrivedEventHandler eventArrivedEventHandler;
            ManagementEventWatcher watcher1;
            ManagementEventWatcher watcher2;

            eventArrivedEventHandler = new EventArrivedEventHandler(myHandler.Win32ProcCreated);
            watcher1 = WmiEventHandler.GetWatcher("__InstanceCreationEvent");
            watcher1.EventArrived += eventArrivedEventHandler;
            watcher1.Start();

            eventArrivedEventHandler = new EventArrivedEventHandler(myHandler.Win32ProcDeleted);
            watcher2 = WmiEventHandler.GetWatcher("__InstanceDeletionEvent");
            watcher2.EventArrived += eventArrivedEventHandler;
            watcher2.Start();

            // spin wheels
            Console.WriteLine("press <enter> to stop...");
            Console.ReadLine();

            // shut down timer & event watchers
            t.Stop();
            watcher1.Stop();
            watcher1.EventArrived -= eventArrivedEventHandler;
            watcher2.Stop();
            watcher2.EventArrived -= eventArrivedEventHandler;
            return 0;
        }

        private static void OnTimer(object sender, System.Timers.ElapsedEventArgs e) {
            if (working) {
                Console.WriteLine("(skipping)");
            } else {
                working = true;

                // Console.WriteLine("Working.");
                HiPerfTimer pt = new HiPerfTimer();     // create a new PerfTimer object
                pt.Start();                             // start the timer

                // capturing screen takes about 0.2 secs 

                String dir = "c:\\temp\\Snapshots2\\";
                String thisDate = TimeFormat.GetDate();
                String thisTime = TimeFormat.GetTime();
                String imgFilename = dir + thisDate + "\\" + thisTime + ".jpg";
                String logFilename = dir + "window-" + thisDate + ".log";

                if (!Directory.Exists(dir + thisDate)) {
                    // make the directory
                    Directory.CreateDirectory(dir + thisDate);
                }
                ScreenCapture sc = new ScreenCapture();
                sc.CaptureScreenToFile(imgFilename, System.Drawing.Imaging.ImageFormat.Jpeg);

                StreamWriter sw = new StreamWriter(logFilename, true); // true = append
                sw.WriteLine("*** Begin " + thisTime);
                Hashtable newProcessMap = getProcessMap();
                List<int> newHwndOrder = new List<int>();
                Hashtable newWindowList = getWindowMap(newHwndOrder);
                mergeProcessMap(sw, newProcessMap);
                mergeWindowMap(sw, newWindowList);
                mergeHwndOrder(sw, newHwndOrder);

                lock (eventList) {
                    // Console.WriteLine("numevents:" + eventList.Count);
                    if (eventList.Count > 0) {
                        String plogFilename = dir + "process-" + thisDate + ".log";
                        StreamWriter sw2 = new StreamWriter(plogFilename, true); // true = append
                        foreach (String s in eventList) {
                            sw2.WriteLine(s);
                        }
                        sw2.Close();
                        eventList.Clear();
                    }
                }

                pt.Stop();                              // stop the timer
                sw.WriteLine("*** Processing time " + pt.Duration);
                sw.Close();
                working = false;
            }
        }


    
    }
}



