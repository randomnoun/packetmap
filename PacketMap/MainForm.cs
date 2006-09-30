using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Tamir.IPLib;
using System.Threading;
using Tamir.IPLib.Packets;

namespace PacketMap {
    public class MainForm : Form {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem cmdStartMapping;
        private ToolStripMenuItem cmdStopMapping;
        private ToolStripMenuItem cmdExit;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem cmdAboutBox;
        private QAlbum.ScalablePictureBox spbImage;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem cmdSelectAdapter;
        private ToolStripSeparator toolStripSeparator1;
        private RichTextBox txtStatus;
        List<CountryGif> countries;
        PcapDevice device = null;
        Thread backgroundThread = null;
        static MainForm mainFormInstance = null;


        public MainForm() {
            InitializeComponent();
            countries = new List<CountryGif>();
            if (mainFormInstance != null) {
                throw new ArgumentException("Program already running!");
            }
            mainFormInstance = this;
            // this.Paint += new PaintEventHandler(f1_paint);
        }

        public void loadCountries(String directory) {
            // grab text file and read from there
            System.IO.StreamReader sr = System.IO.File.OpenText(directory + "\\countries.txt");
            String s;
            while ((s = sr.ReadLine()) != null) {
                s = s.Trim();
                if (!s.Equals("")) {
                    Match m = Regex.Match(s, "^(.*)\\s+([0-9-.]+)\\s+([0-9-.]+)\\s+([0-9-.]+)\\s+([0-9-.]+)\\s*$");
                    if (m.Success) {
                        Console.WriteLine("Loading " + m.Groups[1].Value);
                        countries.Add(new CountryGif(directory + "\\" + m.Groups[1].Value + ".gif",
                            new LngLat(Convert.ToDouble(m.Groups[2].Value), Convert.ToDouble(m.Groups[3].Value)),
                            new LngLat(Convert.ToDouble(m.Groups[4].Value), Convert.ToDouble(m.Groups[5].Value))));
                    } else {
                        throw new ArgumentException("In file 'countries.txt': Invalid string '" + s + "'");
                    }
                }
            }
            sr.Close();
        }

        /*private void f1_paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            CountryGif country = countries[countries.Count-1];
            g.DrawImage(country.getImage(), new Point(0,0));
             
        }*/

        public static void Main(String[] args) {

            if (args.Length > 0 && args[0].Equals("--makeGifs")) {
                // grab all countries, render and save them
                CountryPoly earth = new CountryPoly();
                System.IO.StreamWriter sw = System.IO.File.AppendText("c:\\projects\\pcap\\country\\countries.txt");
                foreach (string file in GetFiles("C:\\projects\\pcap\\outline\\")) {
                    if (new FileInfo(file).Length == 0) {
                        Console.WriteLine("Skipping " + file);
                    } else {
                        String txtFile = file.Substring(file.LastIndexOf("\\") + 1);
                        String gifFile = "c:\\projects\\pcap\\country\\" + txtFile.Substring(0, txtFile.IndexOf(".")) + ".gif";
                        Console.WriteLine("Creating " + gifFile + "...");
                        CountryPoly country = new CountryPoly(file);
                        country.saveToFile(gifFile);
                        earth.loadData(file);
                        sw.WriteLine("{0} {1} {2} {3} {4}", txtFile.Substring(0, txtFile.IndexOf(".")),
                            country.getMinLngLat().getLng(), country.getMinLngLat().getLat(),
                            country.getMaxLngLat().getLng(), country.getMaxLngLat().getLat());
                    }
                }
                earth.saveToFile("c:\\projects\\pcap\\country\\earth.gif");
                sw.WriteLine("earth {0} {1} {2} {3}",
                    earth.getMinLngLat().getLng(), earth.getMinLngLat().getLat(),
                    earth.getMaxLngLat().getLng(), earth.getMaxLngLat().getLat());
                sw.Close();
            }

            MainForm testForm = new MainForm();
            testForm.loadCountries("C:\\projects\\pcap\\country");
            // testForm.loadCountry("C:\\projects\\pcap\\outline\\Australia\\Australia.txt");
            // testForm.loadCountry("C:\\projects\\pcap\\outline\\NorthAmerica\\Canada.txt");

            Application.Run(testForm);
        }

        // creatively borrowed from http://blogs.msdn.com/brada/archive/2004/03/04/84069.aspx
        public static IEnumerable<string>  GetFiles(string path) {
            foreach (string s in Directory.GetFiles(path, "*.txt")) {
                yield return s;
            }
            foreach (string s in Directory.GetDirectories(path)) {
                foreach (string s1 in GetFiles(s)) {
                    yield return s1;
                }
            }
        }

        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdStartMapping = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdStopMapping = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdSelectAdapter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdAboutBox = new System.Windows.Forms.ToolStripMenuItem();
            this.spbImage = new QAlbum.ScalablePictureBox();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(383, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdStartMapping,
            this.cmdStopMapping,
            this.toolStripSeparator2,
            this.cmdSelectAdapter,
            this.toolStripSeparator1,
            this.cmdExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // cmdStartMapping
            // 
            this.cmdStartMapping.Name = "cmdStartMapping";
            this.cmdStartMapping.Size = new System.Drawing.Size(167, 22);
            this.cmdStartMapping.Text = "Start mapping";
            this.cmdStartMapping.Click += new System.EventHandler(this.cmdStartMapping_Click);
            // 
            // cmdStopMapping
            // 
            this.cmdStopMapping.Enabled = false;
            this.cmdStopMapping.Name = "cmdStopMapping";
            this.cmdStopMapping.Size = new System.Drawing.Size(167, 22);
            this.cmdStopMapping.Text = "Stop mapping";
            this.cmdStopMapping.Click += new System.EventHandler(this.cmdStopMapping_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // cmdSelectAdapter
            // 
            this.cmdSelectAdapter.Name = "cmdSelectAdapter";
            this.cmdSelectAdapter.Size = new System.Drawing.Size(167, 22);
            this.cmdSelectAdapter.Text = "Select adapter...";
            this.cmdSelectAdapter.Click += new System.EventHandler(this.cmdSelectAdapter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // cmdExit
            // 
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(167, 22);
            this.cmdExit.Text = "Exit";
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAboutBox});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // cmdAboutBox
            // 
            this.cmdAboutBox.Name = "cmdAboutBox";
            this.cmdAboutBox.Size = new System.Drawing.Size(169, 22);
            this.cmdAboutBox.Text = "About PacketMap";
            this.cmdAboutBox.Click += new System.EventHandler(this.cmdAboutBox_Click);
            // 
            // spbImage
            // 
            this.spbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spbImage.BackColor = System.Drawing.SystemColors.Control;
            this.spbImage.Location = new System.Drawing.Point(13, 28);
            this.spbImage.Name = "spbImage";
            this.spbImage.Picture = null;
            this.spbImage.Size = new System.Drawing.Size(358, 157);
            this.spbImage.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.Location = new System.Drawing.Point(13, 191);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(358, 80);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.Text = "";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(383, 283);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.spbImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public delegate void AddStatusTextDelegate(String text);

        private void addStatusText(String text) {
            this.txtStatus.AppendText(text + "\n");
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            // this.scrollablePictureBox1.Image = countries[countries.Count - 1].getImage();
            this.spbImage.PictureBox.Image = countries[countries.Count - 1].getImage();
            addStatusText("Initialising...");
        }

        private void cmdSelectAdapter_Click(object sender, EventArgs e) {
            SelectAdapterForm frmSelectAdapterForm = new SelectAdapterForm();
            if (frmSelectAdapterForm.ShowDialog()==DialogResult.OK) {
                device = SharpPcap.GetAllDevices()[frmSelectAdapterForm.getDeviceId()];
                addStatusText("Selected adapter " + device.PcapDescription);
            }
        }

        private void cmdExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void cmdAboutBox_Click(object sender, EventArgs e) {
            AboutBox frmAboutbox = new AboutBox();
            frmAboutbox.ShowDialog();
        }

        private void cmdStartMapping_Click(object sender, EventArgs e) {
            cmdStartMapping.Enabled = false;
            cmdStopMapping.Enabled = true;
            cmdSelectAdapter.Enabled = false;

            if (backgroundThread != null && backgroundThread.IsAlive) {
                addStatusText("Terminating thread...");
                backgroundThread.Abort();
                device.PcapClose();
            }

            addStatusText("Started mapping on " + device.PcapDescription + " ...");
            backgroundThread = new Thread(new ParameterizedThreadStart (capturePackets));
            backgroundThread.Start(this);
        }

        static void capturePackets(Object mainForm) {
            PcapDevice device = ((MainForm)mainForm).device;
            //Register our handler function to the 'packet arrival' event
            device.PcapOnPacketArrival += new SharpPcap.PacketArrivalEvent(device_PcapOnPacketArrival);
            //Open the device for capturing
            //true -- means promiscuous mode
            //1000 -- means a read wait of 1000ms
            device.PcapOpen(true, 1000);

            // tcpdump filter to capture only TCP/IP packets			
            device.PcapSetFilter("ip and tcp");

            // should do this in another thread, really.
            device.PcapCapture(SharpPcap.INFINITE); // Start capture 'INFINTE' number of packets
        }

        /// <summary>
        /// Prints the time, length, src ip, src port, dst ip and dst port
        /// for each TCP/IP packet received on the network
        /// </summary>
        private static void device_PcapOnPacketArrival(object sender, Packet packet) {
            // sender in this instance is the PcapDevice object

            if (packet is TCPPacket) {
                DateTime time = packet.PcapHeader.Date;
                int len = packet.PcapHeader.PacketLength;

                TCPPacket tcp = (TCPPacket)packet;
                string srcIp = tcp.SourceAddress;
                string dstIp = tcp.DestinationAddress;
                int srcPort = tcp.SourcePort;
                int dstPort = tcp.DestinationPort;

                String text = String.Format("{0}:{1}:{2},{3} Len={4} {5}:{6} -> {7}:{8}",
                    time.Hour, time.Minute, time.Second, time.Millisecond, len,
                    srcIp, srcPort, dstIp, dstPort);
                //mainFormInstance.addStatusText(text);
                AddStatusTextDelegate del = new AddStatusTextDelegate(mainFormInstance.addStatusText);
                object[] paramList = new object[] { text };
                mainFormInstance.Invoke(del, paramList);

            }
        }

        private void cmdStopMapping_Click(object sender, EventArgs e) {
            cmdStartMapping.Enabled = true;
            cmdStopMapping.Enabled = false;
            cmdSelectAdapter.Enabled = true;

            addStatusText("Terminating thread...");
            backgroundThread.Abort();
            device.PcapClose();
            addStatusText("Mapping stopped.");


        }

    }


    public class LngLat {
        double lng;
        double lat;
        public LngLat(double lng, double lat) {
            this.lng = lng;
            this.lat = lat;
        }
        public double getLng() { return lng; }
        public double getLat() { return lat; }
    }

    public class CountryGif {
        LngLat minLngLat;
        LngLat maxLngLat;
        Image image;
        public CountryGif(String file, LngLat minLngLat, LngLat maxLngLat) {
            image = Image.FromFile(file);
            this.minLngLat = minLngLat;
            this.maxLngLat = maxLngLat;
        }
        public LngLat getMinLngLat() { return minLngLat; }
        public LngLat getMaxLngLat() { return maxLngLat; }
        public Image getImage() { return image; }
    }

    public class CountryPoly {
        List<List<LngLat>> polys;
        Image image = null;

        public CountryPoly() {
            polys = new List<List<LngLat>>();
        }

        public CountryPoly(String file) {
            polys = new List<List<LngLat>>();
            loadData(file);
        }

        public List<List<LngLat>> getPolys() {
            return polys;
        }

        public Image getImage() {
            if (image != null) {
                return image;
            }

            LngLat minLngLat = getMinLngLat();
            LngLat maxLngLat = getMaxLngLat();
            double width = maxLngLat.getLng() - minLngLat.getLng();
            double height = maxLngLat.getLat() - minLngLat.getLat();

            // render to image Convert.ToInt32
            // max is required for Africa/Tromelin Island
            image = new Bitmap(Math.Max(Convert.ToInt32(width * 16), 1), Math.Max(Convert.ToInt32(height * 16), 1));
            Graphics offScreenDC = Graphics.FromImage(image);
            drawCountry(offScreenDC);
            offScreenDC.Dispose();
            return image;
        }

        public void saveToFile(String file) {
            Image image = getImage();
            image.Save(file, System.Drawing.Imaging.ImageFormat.Gif);
        }

        private void drawCountry(Graphics g) {
            g.FillRectangle(new SolidBrush(Color.Black), g.VisibleClipBounds);

            // Method under System.Drawing.Graphics
            //g.DrawString("Welcome C#", new Font("Verdana", 20),
            //new SolidBrush(Color.Tomato), 40, 40);

            LngLat minLngLat = getMinLngLat();
            LngLat maxLngLat = getMaxLngLat();

            minLngLat = new LngLat(Math.Round(minLngLat.getLng()), Math.Round(minLngLat.getLat()));
            maxLngLat = new LngLat(Math.Round(maxLngLat.getLng()), Math.Round(maxLngLat.getLat()));

            for (int j = 0; j < polys.Count; j++) {
                List<LngLat> outline = polys[j];
                Point[] pts = new Point[outline.Count - 1];
                for (int i = 1; i < outline.Count; i++) {  // 0th lnglat is inside poly
                    LngLat lngLat = outline[i];
                    pts[i - 1] = new Point(Convert.ToInt32((lngLat.getLng() - minLngLat.getLng()) * 16),
                          Convert.ToInt32((lngLat.getLat() - minLngLat.getLat()) * 16));
                    // Console.WriteLine("pts[" + i + "]=" + pts[i].X + ", " + pts[i].Y); 
                }
                // Console.WriteLine("count=" + outline.Count);
                // g.DrawPolygon(new Pen(Color.LightGreen, 1), pts);
                g.FillPolygon(new SolidBrush(Color.White), pts);
            }
        }

        public LngLat getMinLngLat() {
            double minLng = polys[0][0].getLng();
            double minLat = polys[0][0].getLat();
            for (int j = 0; j < polys.Count; j++) {
                List<LngLat> outline = polys[j];
                for (int i = 1; i < outline.Count; i++) {  // 0th lnglat is inside poly
                    if (outline[i].getLng() < minLng) { minLng = outline[i].getLng(); }
                    if (outline[i].getLat() < minLat) { minLat = outline[i].getLat(); }
                }
            }
            return new LngLat(minLng, minLat);
        }

        public LngLat getMaxLngLat() {
            double maxLng = polys[0][0].getLng();
            double maxLat = polys[0][0].getLat();
            for (int j = 1; j < polys.Count; j++) {
                List<LngLat> outline = polys[j];
                for (int i = 1; i < outline.Count; i++) {  // 0th lnglat is inside poly
                    if (outline[i].getLng() > maxLng) { maxLng = outline[i].getLng(); }
                    if (outline[i].getLat() > maxLat) { maxLat = outline[i].getLat(); }
                }
            }
            return new LngLat(maxLng, maxLat);
        }


        public void loadData(String file) {

            // polys = new List<List<LngLat>>();
            // Open the file and read it back.
            using (System.IO.StreamReader sr = System.IO.File.OpenText(file)) {
                string s = "";
                string country = sr.ReadLine();
                long polyNum = long.Parse(sr.ReadLine());
                List<LngLat> poly = new List<LngLat>();
                polys.Add(poly);
                Boolean eof = false;
                while ((!eof) && (s = sr.ReadLine()) != null) {
                    s = s.Trim();
                    if (s.Equals("")) {
                        // ignore
                    } else if (s.StartsWith("END")) {
                        // read next polynum, or 'END' for eof
                        s = sr.ReadLine();
                        if (s.StartsWith("END")) {
                            eof = true;
                            // finished, next read should be null
                        } else {
                            Match m = Regex.Match(s, "([0-9-.]*)");
                            if (m.Success) {
                                if (Convert.ToInt64(m.Groups[1].Value) != polyNum + 1) {
                                    throw new ArgumentException("In file '" + file + "': Found poly number '" + m.Groups[1] + "'; expected '" + (polyNum + 1) + "'");
                                } else {
                                    polyNum = polyNum + 1;
                                    poly = new List<LngLat>();
                                    polys.Add(poly);
                                }
                            } else {
                                throw new ArgumentException("In file '" + file + "': Invalid string '" + s + "'");
                            }
                        }
                    } else {
                        Match m = Regex.Match(s, "\\s*([0-9-.]*)\\s*([0-9-.]*)");
                        double lng, lat;
                        if (m.Success) {
                            lng = Convert.ToDouble(m.Groups[1].Value);
                            lat = Convert.ToDouble(m.Groups[2].Value);
                            poly.Add(new LngLat(lng, -lat));
                        } else {
                            throw new ArgumentException("In file '" + file + "': Invalid string '" + s + "'");
                        }
                    }
                }
            }
        }
    }
}
