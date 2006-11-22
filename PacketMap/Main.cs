using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using Microsoft.Win32;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace PacketMap
{
    public class MainProgram {

        public static string VERSION = "pre-alpha-0.3";

        public static void Main(String[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Randomnoun\\Packetmap");
            if (key == null) {
                key = Registry.CurrentUser.CreateSubKey("Software\\Randomnoun\\Packetmap");
            }
            string deviceName = (string) key.GetValue("DeviceName", "");
            string installDir = (string) key.GetValue("InstallDir", "");
            bool autoUpdate = Convert.ToInt32(key.GetValue("AutoUpdate", 1))==1;
            // Attempt to open the key; create it if it doesn't exist
            key.Close();

            if (installDir.Equals("")) {
                MessageBox.Show("Registry key not found -- aborting", "Initialisation failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Splasher.Show(typeof(SplashForm));

            for (int i=0; i<args.Length; i++) {
                string arg = args[i];
                Console.WriteLine("Processing arg '" + arg + "'");
                if (arg.Equals("--makeGifs")) {
                    // grab all countries, render and save them
                    CountryPoly earth = new CountryPoly();
                    // System.IO.StreamWriter sw = System.IO.File.AppendText("c:\\projects\\pcap\\country\\countries.txt");
                    System.IO.StreamWriter sw = System.IO.File.CreateText(installDir + "\\countryGif\\countries.txt");
                    foreach (string file in Util.GetFiles(installDir + "\\countryPoly", "*.txt")) {
                        if (new FileInfo(file).Length == 0) {
                            Console.WriteLine("Skipping " + file);
                        } else {
                            String txtFile = file.Substring(file.LastIndexOf("\\") + 1);
                            String gifFile = "C:\\projects\\packetmap\\PacketMap\\countryGif\\" + txtFile.Substring(0, txtFile.IndexOf(".")) + ".png";
                            Console.WriteLine("Creating " + gifFile + "...");
                            CountryPoly country = new CountryPoly(file);
                            country.saveToFile(gifFile, Color.LightGreen, Color.Transparent);
                            earth.loadData(file);
                            sw.WriteLine("{0} {1} {2} {3} {4}", txtFile.Substring(0, txtFile.IndexOf(".")),
                                country.getMinLngLat().getLng(), country.getMinLngLat().getLat(),
                                country.getMaxLngLat().getLng(), country.getMaxLngLat().getLat());
                        }
                    }
                    earth.saveToFile(installDir + "\\countryGif\\earth.png", Color.FromArgb(62, 94, 67), Color.FromArgb(0, 5, 100));
                    sw.WriteLine("earth {0} {1} {2} {3}",
                        earth.getMinLngLat().getLng(), earth.getMinLngLat().getLat(),
                        earth.getMaxLngLat().getLng(), earth.getMaxLngLat().getLat());
                    sw.Close();
                }

                if (arg.Equals("--makeFlagGif")) {
                    // make flag composite image
                    // installDir = "c:\\projects\\packetmap\\PacketMap";
                    
                    // get maximum flag dimensions
                    int flagCount = 0;
                    int maxW = 0, maxH = 0;
                    foreach (string file in Util.GetFiles(installDir + "\\flags", "*.gif")) {
                        Image miniFlag = Image.FromFile(file);
                        maxW = Math.Max(maxW, miniFlag.Width);
                        maxH = Math.Max(maxH, miniFlag.Height);
                        flagCount++;
                    }

                    System.IO.StreamWriter sw = System.IO.File.CreateText(installDir + "\\data\\flagComposite.txt");
                    sw.WriteLine("Flag dimension data");
                    sw.WriteLine("{0} {1} {2}", flagCount, maxW, maxH);
                    
                    // each flag is 20px by 12px
                    int flagsPerRow = 20;
                    Bitmap b = new Bitmap(maxW * flagsPerRow, maxH * (flagCount / flagsPerRow) + maxH, PixelFormat.Format24bppRgb);
                    Graphics g = Graphics.FromImage(b);
                    g.FillRectangle(Brushes.White, 0, 0, maxW * flagsPerRow, maxH * (flagCount / flagsPerRow) + maxH);
                    flagCount = 0;
                    foreach (string file in Util.GetFiles(installDir + "\\flags", "*.gif")) {
                        Image miniFlag = Image.FromFile(file);
                        string id = file.Substring(file.LastIndexOf("\\")+1);
                        id = id.Substring(0, id.IndexOf("."));
                        g.DrawImage(miniFlag, (flagCount % flagsPerRow) * maxW, (flagCount / flagsPerRow) * maxH);
                        sw.WriteLine("{0} {1} {2}", id, miniFlag.Width, miniFlag.Height);
                        flagCount++;
                    }
                    g.Dispose();
                    b.Save(installDir + "\\data\\flagComposite.png", ImageFormat.Png);
                    sw.Close();
                }
            }



            MainForm testForm = new MainForm(installDir, deviceName, autoUpdate);
            Application.Run(testForm);
        }
    }
}