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
using System.Collections;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Microsoft.Win32;
using System.Net;
using System.ComponentModel;

namespace PacketMap {

    public class MainForm : Form,  QAlbum.OverlayGenerator {
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
        List<GeoIpRange> geoIpRanges;
        Hashtable countryMap;  // shortcode("AU") -> countryGif
        
        CountryGif baseCountry;
        Image baseImage;
        Bitmap overlayBitmap;
        Bitmap compositeBitmap;

        StreamWriter packetWriter;
        long sideListMaxSend = 0;
        long sideListMaxRecv = 0;

        /* PcapDevice device = null; */
        NetworkDevice device = null;
        uint deviceIp = 0;
        bool autoUpdate = false;

        Thread backgroundThread = null;
        private System.Windows.Forms.Timer animationTimer;
        private System.ComponentModel.IContainer components;
        private ListView sideListView;
        private ColumnHeader colCountry;
        private ColumnHeader colSent;
        private ColumnHeader colRecv;
        private ImageList flagImageList;
        private StatusStrip statusBar;
        private ToolStripStatusLabel lblStatusBarLeft;
        private ToolStripMenuItem cmdCheckUpdatesAtStartup;
        private ToolStripMenuItem cmdCheckUpdatesNow;
        private ToolStripSeparator toolStripSeparator3;
        static MainForm mainFormInstance = null;

        public MainForm(string baseDir, string deviceName, bool autoUpdate) {
            InitializeComponent();
            this.autoUpdate = autoUpdate;
            cmdCheckUpdatesAtStartup.Checked = autoUpdate;

            countries = new List<CountryGif>();
            geoIpRanges = new List<GeoIpRange>();
            countryMap = new Hashtable();
            if (mainFormInstance != null) {
                throw new ArgumentException("Program already running!");
            }
            mainFormInstance = this;

            // check for latest update
            // prepare the web page we will be asking for
            if (autoUpdate) {
                Splasher.AddText("Checking for updates (go to Help menu to disable this check)...");
                Splasher.SetProgress(20);
                Thread.Sleep(100);
                checkForUpdatesNow(true);
            }
            
            Splasher.AddText("Loading country outline data...");
            this.loadCountries(baseDir);
            Thread.Sleep(100);
            Splasher.SetProgress(40);

            
            Splasher.AddText("Loading IP to country data...");
            this.loadGeoIps(baseDir + "\\data\\GeoIPCountryWhois.csv");
            this.loadCountryMap(baseDir + "\\data\\matchedWithGif.csv");
            Thread.Sleep(100);
            Splasher.SetProgress(60);

            Splasher.AddText("Loading country flag images...");
            this.loadFlagImages(baseDir + "\\flags");
            baseCountry = countries[countries.Count - 1];
            baseImage = baseCountry.getImage();
            overlayBitmap = new Bitmap(baseImage.Size.Width, baseImage.Size.Height, PixelFormat.Format32bppArgb);
            compositeBitmap = new Bitmap(baseImage.Size.Width, baseImage.Size.Height, PixelFormat.Format32bppArgb);
            this.spbImage.BackingImage = baseImage;
            this.spbImage.SetOverlayGenerator(this);
            Thread.Sleep(100);
            Splasher.SetProgress(80);

            Splasher.AddText("Selecting adaptor...");
            if (!deviceName.Equals("")) {
                try {
                    device = (NetworkDevice) SharpPcap.GetPcapDevice(deviceName);
                    deviceIp = Tamir.IPLib.Util.Convert.IpStringToInt32(device.IpAddress);
                    AddStatusText("Selected adapter " + device.PcapDescription + " [" + device.IpAddress + "]"); 
                } catch (Exception) {
                    AddStatusText("Could not find device '" + deviceName + "'... please reselect adaptor");
                }
            }

            Directory.CreateDirectory(baseDir + "\\out");
            this.packetWriter = System.IO.File.AppendText(baseDir + "\\out\\packetDump.txt");
            Splasher.Close();

            lblStatusBarLeft.Text = "Mapping disabled";
        }


        public class GeoIpRange {
            uint startIp, endIp;
            string countryCode;
            public GeoIpRange(uint startIp, uint endIp, string countryCode) {
                this.startIp = startIp;
                this.endIp = endIp;
                this.countryCode = countryCode;
            }
            public uint getStartIp() { return startIp; }
            public uint getEndIp() { return endIp; }
            public string getCountry() { return countryCode; }
        }

        public class GeoIpRangeComparer : IComparer<GeoIpRange> {
            int IComparer<GeoIpRange>.Compare(GeoIpRange geoIp1, GeoIpRange geoIp2) {
                uint ip = (geoIp2).getStartIp();
                /*
                Console.WriteLine("Searching for " + ip + " (" + 
                    Tamir.IPLib.Util.Convert.IpInt32ToString(ip) + ") between " + geoIp1.getStartIp() + " (" +
                    Tamir.IPLib.Util.Convert.IpInt32ToString(geoIp1.getStartIp()) + ") and " + geoIp1.getEndIp() + "(" +
                    Tamir.IPLib.Util.Convert.IpInt32ToString(geoIp1.getEndIp()) + ")");
                */
                if (ip < geoIp1.getStartIp()) { return 1; }
                if (ip > geoIp1.getEndIp()) { return -1; }
                return 0;
            }
        }



        public void loadGeoIps(String file) {
            // grab text file and read from there
            Console.WriteLine("Reading geoip data...");
            System.IO.StreamReader sr = System.IO.File.OpenText(file);
            String s;
            int lines = 0;
            while ((s = sr.ReadLine()) != null) {
                // in form "2.6.190.56","2.6.190.63","33996344","33996351","GB","United Kingdom"
                string[] data = s.Split(new char[] { ',' });
                // just get uin32 IPs, and short country code
                GeoIpRange geoIpRange = new GeoIpRange(
                    Convert.ToUInt32(data[2].Substring(1, data[2].Length - 2)),
                    Convert.ToUInt32(data[3].Substring(1, data[3].Length - 2)),
                    data[4].Substring(1, data[4].Length - 2));
                geoIpRanges.Add(geoIpRange);
                lines++;
                if (lines % 100 == 0) {
                    Console.Write(".");
                    if (lines % 7000 == 0) {
                        Console.Write("\n");
                    }
                }
            }
            Console.WriteLine();
            sr.Close();
        }


        public void loadFlagImages(String directory) {
            foreach (String countryCode in countryMap.Keys) {
                int index = flagImageList.Images.IndexOfKey(countryCode.ToLower() + ".gif");
                CountryGif countryGif = (CountryGif)countryMap[countryCode];
                countryGif.setFlagIndex(index);
                if (index == -1) {
                    AddStatusText("Could not find image for country code '" + countryCode + "'");
                }
            }
            
            //foreach (Image img in flagImageList.Images) {
            //    IndexOfKey
            //}


            /*foreach (string file in GetFiles(directory, "*.png")) {
                String gifFile = file.Substring(file.LastIndexOf("\\") + 1);
                String countryCode = gifFile.Substring(0, gifFile.IndexOf(".")).ToUpper();
                // find countryGif object
                CountryGif countryGif = (CountryGif) countryMap[countryCode];
                if (countryGif==null) {
                    // should complain
                } else {
                    countryGif.setFlagIndex(i); i++;
                    
                }
            }*/
        }
        
        public void loadCountryMap(String file) {
            // grab text file and read from there
            Console.WriteLine("Reading country map data...");
            System.IO.StreamReader sr = System.IO.File.OpenText(file);
            String s;
            while ((s = sr.ReadLine()) != null) {
                // TK,Tokelau,
                // AU,Australia,Australia
                String[] data = s.Split(new char[] { ',' });
                if (data.Length == 3) {
                    // find country with this name
                    Boolean found = false;
                    foreach (CountryGif country in countries) {
                        if (country.getName() == data[2]) {
                            countryMap.Add(data[0], country);
                            country.setShortName(data[0]);
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        Console.WriteLine("Country " + data[0] + " '" + data[1] + "' missing from map");
                    }
                }
            }
            Console.WriteLine();
            sr.Close();
        }


        public void loadCountries(String directory) {
            // grab text file and read from there
            System.IO.StreamReader sr = System.IO.File.OpenText(directory + "\\data\\countries.txt");
            String s;
            while ((s = sr.ReadLine()) != null) {
                s = s.Trim();
                if (!s.Equals("")) {
                    Match m = Regex.Match(s, "^(.*)\\s+([0-9-.]+)\\s+([0-9-.]+)\\s+([0-9-.]+)\\s+([0-9-.]+)\\s*$");
                    if (m.Success) {
                        Console.WriteLine("Loading " + m.Groups[1].Value);
                        countries.Add(new CountryGif(directory + "\\countryGif\\" + m.Groups[1].Value + ".png",
                            m.Groups[1].Value,
                            new LngLat(Convert.ToDouble(m.Groups[2].Value), Convert.ToDouble(m.Groups[3].Value)),
                            new LngLat(Convert.ToDouble(m.Groups[4].Value), Convert.ToDouble(m.Groups[5].Value))));
                    } else {
                        throw new ArgumentException("In file 'countries.txt': Invalid string '" + s + "'");
                    }
                }
            }
            sr.Close();
        }

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.sideListView = new System.Windows.Forms.ListView();
            this.colCountry = new System.Windows.Forms.ColumnHeader();
            this.colSent = new System.Windows.Forms.ColumnHeader();
            this.colRecv = new System.Windows.Forms.ColumnHeader();
            this.flagImageList = new System.Windows.Forms.ImageList(this.components);
            this.spbImage = new QAlbum.ScalablePictureBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatusBarLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdCheckUpdatesAtStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdCheckUpdatesNow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(538, 24);
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
            this.cmdCheckUpdatesAtStartup,
            this.cmdCheckUpdatesNow,
            this.toolStripSeparator3,
            this.cmdAboutBox});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // cmdAboutBox
            // 
            this.cmdAboutBox.Name = "cmdAboutBox";
            this.cmdAboutBox.Size = new System.Drawing.Size(224, 22);
            this.cmdAboutBox.Text = "About PacketMap";
            this.cmdAboutBox.Click += new System.EventHandler(this.cmdAboutBox_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatus.BackColor = System.Drawing.Color.Black;
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtStatus.Location = new System.Drawing.Point(152, 191);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(374, 67);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.Text = "";
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 1000;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // sideListView
            // 
            this.sideListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.sideListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCountry,
            this.colSent,
            this.colRecv});
            this.sideListView.GridLines = true;
            this.sideListView.Location = new System.Drawing.Point(12, 27);
            this.sideListView.Name = "sideListView";
            this.sideListView.OwnerDraw = true;
            this.sideListView.Size = new System.Drawing.Size(134, 231);
            this.sideListView.SmallImageList = this.flagImageList;
            this.sideListView.TabIndex = 3;
            this.sideListView.UseCompatibleStateImageBehavior = false;
            this.sideListView.View = System.Windows.Forms.View.Details;
            this.sideListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.sideListView_DrawItem);
            this.sideListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.sideListView_DrawSubItem);
            this.sideListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sideListView_MouseUp);
            this.sideListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sideListView_MouseMove);
            this.sideListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.sideListView_DrawColumnHeader);
            // 
            // colCountry
            // 
            this.colCountry.Text = "Country";
            this.colCountry.Width = 70;
            // 
            // colSent
            // 
            this.colSent.Text = "Sent";
            this.colSent.Width = 30;
            // 
            // colRecv
            // 
            this.colRecv.Text = "Recv";
            this.colRecv.Width = 30;
            // 
            // flagImageList
            // 
            this.flagImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("flagImageList.ImageStream")));
            this.flagImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.flagImageList.Images.SetKeyName(0, "-.gif");
            this.flagImageList.Images.SetKeyName(1, "ad.gif");
            this.flagImageList.Images.SetKeyName(2, "ae.gif");
            this.flagImageList.Images.SetKeyName(3, "af.gif");
            this.flagImageList.Images.SetKeyName(4, "ag.gif");
            this.flagImageList.Images.SetKeyName(5, "ai.gif");
            this.flagImageList.Images.SetKeyName(6, "al.gif");
            this.flagImageList.Images.SetKeyName(7, "am.gif");
            this.flagImageList.Images.SetKeyName(8, "an.gif");
            this.flagImageList.Images.SetKeyName(9, "ao.gif");
            this.flagImageList.Images.SetKeyName(10, "aq.gif");
            this.flagImageList.Images.SetKeyName(11, "ar.gif");
            this.flagImageList.Images.SetKeyName(12, "as.gif");
            this.flagImageList.Images.SetKeyName(13, "at.gif");
            this.flagImageList.Images.SetKeyName(14, "au.gif");
            this.flagImageList.Images.SetKeyName(15, "aw.gif");
            this.flagImageList.Images.SetKeyName(16, "az.gif");
            this.flagImageList.Images.SetKeyName(17, "ba.gif");
            this.flagImageList.Images.SetKeyName(18, "bb.gif");
            this.flagImageList.Images.SetKeyName(19, "bd.gif");
            this.flagImageList.Images.SetKeyName(20, "be.gif");
            this.flagImageList.Images.SetKeyName(21, "bf.gif");
            this.flagImageList.Images.SetKeyName(22, "bg.gif");
            this.flagImageList.Images.SetKeyName(23, "bh.gif");
            this.flagImageList.Images.SetKeyName(24, "bi.gif");
            this.flagImageList.Images.SetKeyName(25, "bj.gif");
            this.flagImageList.Images.SetKeyName(26, "bm.gif");
            this.flagImageList.Images.SetKeyName(27, "bn.gif");
            this.flagImageList.Images.SetKeyName(28, "bo.gif");
            this.flagImageList.Images.SetKeyName(29, "br.gif");
            this.flagImageList.Images.SetKeyName(30, "bs.gif");
            this.flagImageList.Images.SetKeyName(31, "bt.gif");
            this.flagImageList.Images.SetKeyName(32, "bv.gif");
            this.flagImageList.Images.SetKeyName(33, "bw.gif");
            this.flagImageList.Images.SetKeyName(34, "by.gif");
            this.flagImageList.Images.SetKeyName(35, "bz.gif");
            this.flagImageList.Images.SetKeyName(36, "ca.gif");
            this.flagImageList.Images.SetKeyName(37, "cd.gif");
            this.flagImageList.Images.SetKeyName(38, "cf.gif");
            this.flagImageList.Images.SetKeyName(39, "cg.gif");
            this.flagImageList.Images.SetKeyName(40, "ch.gif");
            this.flagImageList.Images.SetKeyName(41, "ci.gif");
            this.flagImageList.Images.SetKeyName(42, "ck.gif");
            this.flagImageList.Images.SetKeyName(43, "cl.gif");
            this.flagImageList.Images.SetKeyName(44, "cm.gif");
            this.flagImageList.Images.SetKeyName(45, "cn.gif");
            this.flagImageList.Images.SetKeyName(46, "co.gif");
            this.flagImageList.Images.SetKeyName(47, "cr.gif");
            this.flagImageList.Images.SetKeyName(48, "cs.gif");
            this.flagImageList.Images.SetKeyName(49, "cu.gif");
            this.flagImageList.Images.SetKeyName(50, "cv.gif");
            this.flagImageList.Images.SetKeyName(51, "cy.gif");
            this.flagImageList.Images.SetKeyName(52, "cz.gif");
            this.flagImageList.Images.SetKeyName(53, "de.gif");
            this.flagImageList.Images.SetKeyName(54, "dj.gif");
            this.flagImageList.Images.SetKeyName(55, "dk.gif");
            this.flagImageList.Images.SetKeyName(56, "dm.gif");
            this.flagImageList.Images.SetKeyName(57, "do.gif");
            this.flagImageList.Images.SetKeyName(58, "dz.gif");
            this.flagImageList.Images.SetKeyName(59, "ec.gif");
            this.flagImageList.Images.SetKeyName(60, "ee.gif");
            this.flagImageList.Images.SetKeyName(61, "eg.gif");
            this.flagImageList.Images.SetKeyName(62, "er.gif");
            this.flagImageList.Images.SetKeyName(63, "es.gif");
            this.flagImageList.Images.SetKeyName(64, "et.gif");
            this.flagImageList.Images.SetKeyName(65, "eu.gif");
            this.flagImageList.Images.SetKeyName(66, "fi.gif");
            this.flagImageList.Images.SetKeyName(67, "fj.gif");
            this.flagImageList.Images.SetKeyName(68, "fk.gif");
            this.flagImageList.Images.SetKeyName(69, "fm.gif");
            this.flagImageList.Images.SetKeyName(70, "fo.gif");
            this.flagImageList.Images.SetKeyName(71, "fr.gif");
            this.flagImageList.Images.SetKeyName(72, "ga.gif");
            this.flagImageList.Images.SetKeyName(73, "gb.gif");
            this.flagImageList.Images.SetKeyName(74, "gd.gif");
            this.flagImageList.Images.SetKeyName(75, "ge.gif");
            this.flagImageList.Images.SetKeyName(76, "gh.gif");
            this.flagImageList.Images.SetKeyName(77, "gi.gif");
            this.flagImageList.Images.SetKeyName(78, "gl.gif");
            this.flagImageList.Images.SetKeyName(79, "gm.gif");
            this.flagImageList.Images.SetKeyName(80, "gn.gif");
            this.flagImageList.Images.SetKeyName(81, "gp.gif");
            this.flagImageList.Images.SetKeyName(82, "gq.gif");
            this.flagImageList.Images.SetKeyName(83, "gr.gif");
            this.flagImageList.Images.SetKeyName(84, "gt.gif");
            this.flagImageList.Images.SetKeyName(85, "gu.gif");
            this.flagImageList.Images.SetKeyName(86, "gw.gif");
            this.flagImageList.Images.SetKeyName(87, "gy.gif");
            this.flagImageList.Images.SetKeyName(88, "hk.gif");
            this.flagImageList.Images.SetKeyName(89, "hm.gif");
            this.flagImageList.Images.SetKeyName(90, "hn.gif");
            this.flagImageList.Images.SetKeyName(91, "hr.gif");
            this.flagImageList.Images.SetKeyName(92, "ht.gif");
            this.flagImageList.Images.SetKeyName(93, "hu.gif");
            this.flagImageList.Images.SetKeyName(94, "id.gif");
            this.flagImageList.Images.SetKeyName(95, "ie.gif");
            this.flagImageList.Images.SetKeyName(96, "il.gif");
            this.flagImageList.Images.SetKeyName(97, "im.gif");
            this.flagImageList.Images.SetKeyName(98, "in.gif");
            this.flagImageList.Images.SetKeyName(99, "io.gif");
            this.flagImageList.Images.SetKeyName(100, "iq.gif");
            this.flagImageList.Images.SetKeyName(101, "ir.gif");
            this.flagImageList.Images.SetKeyName(102, "is.gif");
            this.flagImageList.Images.SetKeyName(103, "it.gif");
            this.flagImageList.Images.SetKeyName(104, "je.gif");
            this.flagImageList.Images.SetKeyName(105, "jm.gif");
            this.flagImageList.Images.SetKeyName(106, "jo.gif");
            this.flagImageList.Images.SetKeyName(107, "jp.gif");
            this.flagImageList.Images.SetKeyName(108, "ke.gif");
            this.flagImageList.Images.SetKeyName(109, "kg.gif");
            this.flagImageList.Images.SetKeyName(110, "kh.gif");
            this.flagImageList.Images.SetKeyName(111, "ki.gif");
            this.flagImageList.Images.SetKeyName(112, "km.gif");
            this.flagImageList.Images.SetKeyName(113, "kn.gif");
            this.flagImageList.Images.SetKeyName(114, "kp.gif");
            this.flagImageList.Images.SetKeyName(115, "kr.gif");
            this.flagImageList.Images.SetKeyName(116, "kw.gif");
            this.flagImageList.Images.SetKeyName(117, "ky.gif");
            this.flagImageList.Images.SetKeyName(118, "kz.gif");
            this.flagImageList.Images.SetKeyName(119, "la.gif");
            this.flagImageList.Images.SetKeyName(120, "lb.gif");
            this.flagImageList.Images.SetKeyName(121, "lc.gif");
            this.flagImageList.Images.SetKeyName(122, "li.gif");
            this.flagImageList.Images.SetKeyName(123, "lk.gif");
            this.flagImageList.Images.SetKeyName(124, "lr.gif");
            this.flagImageList.Images.SetKeyName(125, "ls.gif");
            this.flagImageList.Images.SetKeyName(126, "lt.gif");
            this.flagImageList.Images.SetKeyName(127, "lu.gif");
            this.flagImageList.Images.SetKeyName(128, "lv.gif");
            this.flagImageList.Images.SetKeyName(129, "ly.gif");
            this.flagImageList.Images.SetKeyName(130, "ma.gif");
            this.flagImageList.Images.SetKeyName(131, "mc.gif");
            this.flagImageList.Images.SetKeyName(132, "md.gif");
            this.flagImageList.Images.SetKeyName(133, "mg.gif");
            this.flagImageList.Images.SetKeyName(134, "mh.gif");
            this.flagImageList.Images.SetKeyName(135, "mk.gif");
            this.flagImageList.Images.SetKeyName(136, "ml.gif");
            this.flagImageList.Images.SetKeyName(137, "mm.gif");
            this.flagImageList.Images.SetKeyName(138, "mn.gif");
            this.flagImageList.Images.SetKeyName(139, "mo.gif");
            this.flagImageList.Images.SetKeyName(140, "mp.gif");
            this.flagImageList.Images.SetKeyName(141, "mq.gif");
            this.flagImageList.Images.SetKeyName(142, "mr.gif");
            this.flagImageList.Images.SetKeyName(143, "ms.gif");
            this.flagImageList.Images.SetKeyName(144, "mt.gif");
            this.flagImageList.Images.SetKeyName(145, "mu.gif");
            this.flagImageList.Images.SetKeyName(146, "mv.gif");
            this.flagImageList.Images.SetKeyName(147, "mw.gif");
            this.flagImageList.Images.SetKeyName(148, "mx.gif");
            this.flagImageList.Images.SetKeyName(149, "my.gif");
            this.flagImageList.Images.SetKeyName(150, "mz.gif");
            this.flagImageList.Images.SetKeyName(151, "na.gif");
            this.flagImageList.Images.SetKeyName(152, "nc.gif");
            this.flagImageList.Images.SetKeyName(153, "ne.gif");
            this.flagImageList.Images.SetKeyName(154, "nf.gif");
            this.flagImageList.Images.SetKeyName(155, "ng.gif");
            this.flagImageList.Images.SetKeyName(156, "ni.gif");
            this.flagImageList.Images.SetKeyName(157, "nl.gif");
            this.flagImageList.Images.SetKeyName(158, "no.gif");
            this.flagImageList.Images.SetKeyName(159, "np.gif");
            this.flagImageList.Images.SetKeyName(160, "nr.gif");
            this.flagImageList.Images.SetKeyName(161, "nz.gif");
            this.flagImageList.Images.SetKeyName(162, "om.gif");
            this.flagImageList.Images.SetKeyName(163, "pa.gif");
            this.flagImageList.Images.SetKeyName(164, "pe.gif");
            this.flagImageList.Images.SetKeyName(165, "pf.gif");
            this.flagImageList.Images.SetKeyName(166, "pg.gif");
            this.flagImageList.Images.SetKeyName(167, "ph.gif");
            this.flagImageList.Images.SetKeyName(168, "pk.gif");
            this.flagImageList.Images.SetKeyName(169, "pl.gif");
            this.flagImageList.Images.SetKeyName(170, "pm.gif");
            this.flagImageList.Images.SetKeyName(171, "pr.gif");
            this.flagImageList.Images.SetKeyName(172, "ps.gif");
            this.flagImageList.Images.SetKeyName(173, "pt.gif");
            this.flagImageList.Images.SetKeyName(174, "pw.gif");
            this.flagImageList.Images.SetKeyName(175, "py.gif");
            this.flagImageList.Images.SetKeyName(176, "qa.gif");
            this.flagImageList.Images.SetKeyName(177, "re.gif");
            this.flagImageList.Images.SetKeyName(178, "ro.gif");
            this.flagImageList.Images.SetKeyName(179, "ru.gif");
            this.flagImageList.Images.SetKeyName(180, "rw.gif");
            this.flagImageList.Images.SetKeyName(181, "sa.gif");
            this.flagImageList.Images.SetKeyName(182, "sb.gif");
            this.flagImageList.Images.SetKeyName(183, "sc.gif");
            this.flagImageList.Images.SetKeyName(184, "sd.gif");
            this.flagImageList.Images.SetKeyName(185, "se.gif");
            this.flagImageList.Images.SetKeyName(186, "sg.gif");
            this.flagImageList.Images.SetKeyName(187, "si.gif");
            this.flagImageList.Images.SetKeyName(188, "sk.gif");
            this.flagImageList.Images.SetKeyName(189, "sl.gif");
            this.flagImageList.Images.SetKeyName(190, "sm.gif");
            this.flagImageList.Images.SetKeyName(191, "sn.gif");
            this.flagImageList.Images.SetKeyName(192, "so.gif");
            this.flagImageList.Images.SetKeyName(193, "sr.gif");
            this.flagImageList.Images.SetKeyName(194, "st.gif");
            this.flagImageList.Images.SetKeyName(195, "sv.gif");
            this.flagImageList.Images.SetKeyName(196, "sy.gif");
            this.flagImageList.Images.SetKeyName(197, "sz.gif");
            this.flagImageList.Images.SetKeyName(198, "tc.gif");
            this.flagImageList.Images.SetKeyName(199, "td.gif");
            this.flagImageList.Images.SetKeyName(200, "tf.gif");
            this.flagImageList.Images.SetKeyName(201, "tg.gif");
            this.flagImageList.Images.SetKeyName(202, "th.gif");
            this.flagImageList.Images.SetKeyName(203, "tj.gif");
            this.flagImageList.Images.SetKeyName(204, "tm.gif");
            this.flagImageList.Images.SetKeyName(205, "tn.gif");
            this.flagImageList.Images.SetKeyName(206, "to.gif");
            this.flagImageList.Images.SetKeyName(207, "tp.gif");
            this.flagImageList.Images.SetKeyName(208, "tr.gif");
            this.flagImageList.Images.SetKeyName(209, "tt.gif");
            this.flagImageList.Images.SetKeyName(210, "tv.gif");
            this.flagImageList.Images.SetKeyName(211, "tw.gif");
            this.flagImageList.Images.SetKeyName(212, "tz.gif");
            this.flagImageList.Images.SetKeyName(213, "ua.gif");
            this.flagImageList.Images.SetKeyName(214, "ug.gif");
            this.flagImageList.Images.SetKeyName(215, "uk.gif");
            this.flagImageList.Images.SetKeyName(216, "um.gif");
            this.flagImageList.Images.SetKeyName(217, "us.gif");
            this.flagImageList.Images.SetKeyName(218, "uy.gif");
            this.flagImageList.Images.SetKeyName(219, "uz.gif");
            this.flagImageList.Images.SetKeyName(220, "va.gif");
            this.flagImageList.Images.SetKeyName(221, "vc.gif");
            this.flagImageList.Images.SetKeyName(222, "ve.gif");
            this.flagImageList.Images.SetKeyName(223, "vg.gif");
            this.flagImageList.Images.SetKeyName(224, "vi.gif");
            this.flagImageList.Images.SetKeyName(225, "vn.gif");
            this.flagImageList.Images.SetKeyName(226, "vu.gif");
            this.flagImageList.Images.SetKeyName(227, "ws.gif");
            this.flagImageList.Images.SetKeyName(228, "ye.gif");
            this.flagImageList.Images.SetKeyName(229, "yu.gif");
            this.flagImageList.Images.SetKeyName(230, "za.gif");
            this.flagImageList.Images.SetKeyName(231, "zm.gif");
            this.flagImageList.Images.SetKeyName(232, "zr.gif");
            this.flagImageList.Images.SetKeyName(233, "zw.gif");
            // 
            // spbImage
            // 
            this.spbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spbImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(5)))), ((int)(((byte)(100)))));
            this.spbImage.BackingImage = null;
            this.spbImage.Location = new System.Drawing.Point(152, 28);
            this.spbImage.Name = "spbImage";
            this.spbImage.NeedDisposeImage = false;
            this.spbImage.ScalePercent = 1F;
            this.spbImage.Size = new System.Drawing.Size(374, 157);
            this.spbImage.TabIndex = 1;
            this.spbImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spbImage_MouseMove);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusBarLeft});
            this.statusBar.Location = new System.Drawing.Point(0, 261);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(538, 22);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "statusStrip1";
            // 
            // lblStatusBarLeft
            // 
            this.lblStatusBarLeft.Name = "lblStatusBarLeft";
            this.lblStatusBarLeft.Size = new System.Drawing.Size(109, 17);
            this.lblStatusBarLeft.Text = "toolStripStatusLabel1";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // cmdCheckUpdatesAtStartup
            // 
            this.cmdCheckUpdatesAtStartup.Name = "cmdCheckUpdatesAtStartup";
            this.cmdCheckUpdatesAtStartup.Size = new System.Drawing.Size(224, 22);
            this.cmdCheckUpdatesAtStartup.Text = "Check for updates at startup";
            this.cmdCheckUpdatesAtStartup.Click += new System.EventHandler(this.cmdCheckUpdatesAtStartup_Click);
            // 
            // cmdCheckUpdatesNow
            // 
            this.cmdCheckUpdatesNow.Name = "cmdCheckUpdatesNow";
            this.cmdCheckUpdatesNow.Size = new System.Drawing.Size(224, 22);
            this.cmdCheckUpdatesNow.Text = "Check for updates now...";
            this.cmdCheckUpdatesNow.Click += new System.EventHandler(this.cmdCheckUpdatesNow_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(538, 283);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.sideListView);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.spbImage);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PacketMap";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// These need to be delegates because they're called from different threads
        /// (I think). I get errors if I try to call them directly, at any rate.
        /// </summary>
        /// <param name="text">text to display</param>
        public delegate void AddStatusTextDelegate(String text);

        public delegate void AddPacketDelegate(Packet packet);

        private void AddStatusText(String text) {
            this.txtStatus.AppendText(text + "\n");
        }

        private void AddPacket(Packet packet) {
            if (packet is TCPPacket) {
                
                DateTime time = packet.PcapHeader.Date;
                int len = packet.PcapHeader.PacketLength;
                TCPPacket tcp = (TCPPacket)packet;
                Boolean incoming = true;
                string direction;
                string searchIps = "";
                UInt32 searchIp = 0;
                if (deviceIp == tcp.SourceAddressAsLong) {
                    direction = "local:" + tcp.SourcePort + " -> " + tcp.DestinationAddress + ":" + tcp.DestinationPort;
                    searchIp = (uint) tcp.DestinationAddressAsLong;
                    searchIps = tcp.DestinationAddress;
                    incoming = false;
                } else if (deviceIp == tcp.DestinationAddressAsLong) {
                    direction = tcp.SourceAddress + ":" + tcp.SourcePort + " -> local:" + tcp.DestinationPort;
                    searchIp = (uint) tcp.SourceAddressAsLong;
                    searchIps = tcp.SourceAddress;
                    incoming = true;
                } else {
                    direction = tcp.SourceAddress + ":" + tcp.SourcePort + " -> " + tcp.DestinationAddress + ":" + tcp.DestinationPort;
                    searchIp = 0;
                    searchIps = "";
                }

                // parse data
                byte[] data = tcp.TCPData;
                String s = "", l = "", url, host = "";
                int bufpos = 0;
                bool eohttpheaders = false;
                bool foundhost = false;
                bool inhttprequest = false;
                
                if (packetWriter != null) {
                    try {

                        if (!incoming && tcp.DestinationPort == 80 && data.Length > 5) {
                            if (data[0] == 'G' && data[1] == 'E' && data[2] == 'T' && data[3] == ' ') {
                                // line is delimited by CR LF (\r\n)or a single LF (\n). Hopefully.
                                // @TODO make more efficient using array iteration, not string
                                s = System.Text.Encoding.ASCII.GetString(data);
                                int pos = s.IndexOf('\n');
                                if (pos > 1) {
                                    if (s.Substring(pos - 1, 2).Equals("\r\n")) { l = s.Substring(0, pos - 1); } else { l = s.Substring(0, pos); }
                                    bufpos = pos + 1;
                                    if (l.Length > 13 && l.EndsWith(" HTTP/1.1") || l.EndsWith(" HTTP/1.0")) {
                                        url = s.Substring(4, l.Length - 4 - 9);
                                        packetWriter.WriteLine(direction + ": URL: " + url);
                                    }
                                    inhttprequest = true;
                                }

                            } else if (data[0] == 'P' && data[1] == 'O' && data[2] == 'S' && data[3] == 'T' && data[4] == ' ') {
                                s = System.Text.Encoding.ASCII.GetString(data);
                                int pos = s.IndexOf('\n');
                                if (pos > 1) {
                                    if (s.Substring(pos - 1, 2).Equals("\r\n")) { l = s.Substring(0, pos - 1); } else { l = s.Substring(0, pos); }
                                    bufpos = pos + 1;
                                    if (l.Length > 13 && l.EndsWith(" HTTP/1.1") || l.EndsWith(" HTTP/1.0")) {
                                        url = s.Substring(5, l.Length - 5 - 9);
                                        packetWriter.WriteLine(direction + ": URL: " + url);
                                    }
                                    inhttprequest = true;
                                }

                            } else {
                                // @TODO - other HTTP commands here
                            }
                            if (inhttprequest) {
                                // parse http headers
                                while (!eohttpheaders && !foundhost && bufpos < s.Length - 5) {
                                    int pos = s.IndexOf("\n", bufpos);
                                    if (pos > bufpos) {
                                        if (s.Substring(pos - 1, 2).Equals("\r\n")) { l = s.Substring(bufpos, pos - bufpos - 1); } else { l = s.Substring(bufpos, pos); }
                                        bufpos = pos + 1;
                                        int cpos = l.IndexOf(":");
                                        if (l.Equals("")) {
                                            eohttpheaders = true;
                                        } else if (cpos != -1) {
                                            string s1 = l.Substring(0, cpos);
                                            string s2 = l.Substring(cpos + 1);
                                            if (s1.Equals("Host")) {
                                                foundhost = true;
                                                host = s2;
                                            }
                                        } else {

                                            // illegal or truncated header; just abort
                                            eohttpheaders = true;
                                        }
                                    } else {
                                        // no newline found; just finish
                                        eohttpheaders = true;
                                    }
                                }
                                if (foundhost) {
                                    packetWriter.WriteLine(" * host = " + host);
                                }
                            }
                        }

                    } catch (Exception e) {
                        packetWriter.WriteLine("Exception found: " + e.Message);
                    }
                    // packetWriter.WriteLine(direction + ": " + System.Text.Encoding.ASCII.GetString(data));
                }


                //String text = String.Format("{0}:{1}:{2},{3} Len={4} {5}:{6} -> {7}:{8}",
                //    time.Hour, time.Minute, time.Second, time.Millisecond, len,
                //    srcIp, srcPort, dstIp, dstPort);

                // find country
                string search = "";
                if (searchIp != 0) {
                    // int index = geoIpRanges.BinarySearch();
                    int index = geoIpRanges.BinarySearch(new GeoIpRange(searchIp, searchIp, null), new GeoIpRangeComparer());
                    if (index > 0) {
                        GeoIpRange ipRange = geoIpRanges[index];
                        search = "Found in range " + Tamir.IPLib.Util.Convert.IpInt32ToString(ipRange.getStartIp()) + "-" +
                            Tamir.IPLib.Util.Convert.IpInt32ToString(ipRange.getEndIp()) + "; country=" + ipRange.getCountry();
                        CountryGif countryGif = (CountryGif) countryMap[ipRange.getCountry()];
                        if (countryGif != null) {
                            search = search + " [" + ((CountryGif) countryMap[ipRange.getCountry()]).getName() + "]";
                            if (incoming) {
                                countryGif.received(data.Length, searchIps);
                            } else {
                                countryGif.sent(data.Length, searchIps);
                            }
                        }
                    } else {
                        search = "Not found";
                    }
                }

                AddStatusText(direction + " " + search + "\n");
            }
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            // used to have initialisation stuff here; now in constructor
            // (so that splash screen is shown first)
        }

        private void cmdSelectAdapter_Click(object sender, EventArgs e) {
            SelectAdapterForm frmSelectAdapterForm = new SelectAdapterForm();
            if (frmSelectAdapterForm.ShowDialog()==DialogResult.OK) {
                device = (NetworkDevice) SharpPcap.GetAllDevices()[frmSelectAdapterForm.getDeviceId()];
                deviceIp = Tamir.IPLib.Util.Convert.IpStringToInt32(device.PcapIpAddress);
                AddStatusText("Selected adapter " + device.PcapDescription);

                // Attempt to write to registry
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Randomnoun\\Packetmap", true);
                // If the return value is null, the key doesn't exist
                if (key == null) {
                    key = Registry.CurrentUser.CreateSubKey("Software\\Randomnoun\\Packetmap");
                }
                key.SetValue("DeviceName", device.PcapName);
                key.Close();

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
            if (device == null) {
                // @TODO make this a msgbox
                AddStatusText("Please select a device first");
                return;
            }

            cmdStartMapping.Enabled = false;
            cmdStopMapping.Enabled = true;
            cmdSelectAdapter.Enabled = false;

            if (backgroundThread != null && backgroundThread.IsAlive) {
                AddStatusText("Terminating thread...");
                backgroundThread.Abort();
                device.PcapClose();
            }
            

            AddStatusText("Started mapping on " + device.PcapDescription + " ...");
            lblStatusBarLeft.Text = "Mapping enabled";
            backgroundThread = new Thread(new ParameterizedThreadStart (capturePackets));
            backgroundThread.Start(this);
            animationTimer.Start();
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
                //mainFormInstance.addStatusText(text);
                AddPacketDelegate del = new AddPacketDelegate(mainFormInstance.AddPacket);
                object[] paramList = new object[] { packet };
                mainFormInstance.Invoke(del, paramList);
            }
        }

        private void cmdStopMapping_Click(object sender, EventArgs e) {
            cmdStartMapping.Enabled = true;
            cmdStopMapping.Enabled = false;
            cmdSelectAdapter.Enabled = true;

            AddStatusText("Terminating thread...");
            backgroundThread.Abort();
            device.PcapClose();
            animationTimer.Stop();  // TODO: should stop after all countries are gone, but hey
            AddStatusText("Mapping stopped.");
            lblStatusBarLeft.Text = "Mapping disabled";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (backgroundThread != null) { backgroundThread.Abort(); }
            if (device != null) { device.PcapClose(); }
            if (packetWriter != null) { packetWriter.Close(); }
            animationTimer.Stop();
        }

        string _refreshTime = "(not started)";
        private void animationTimer_Tick(object sender, EventArgs e) {
            sideListView.BeginUpdate();
            sideListView.Items.Clear();
            sideListMaxSend = 0;
            sideListMaxRecv = 0;
            // see what overlays we need to put on the earth image
            DateTime now = DateTime.Now;

            Bitmap bitmap = new Bitmap(baseImage);
            Graphics objGraphics = Graphics.FromImage(bitmap);
            foreach (CountryGif country in countries) {
                country.shift();
                double recvHighlight = double.MaxValue;
                double sendHighlight = double.MaxValue;
                DateTime lastReceiveTime = country.getLastReceiveTime();
                DateTime lastSendTime = country.getLastSendTime();
                if (lastReceiveTime != null) {
                    TimeSpan duration = now - lastReceiveTime;
                    recvHighlight = (int) duration.TotalSeconds;
                }
                if (lastSendTime != null) {
                    TimeSpan duration = now - lastSendTime;
                    sendHighlight = (int) duration.TotalSeconds;
                }
                /* - for debugging
                if (country.getName().Equals("Australia")) {
                    this.AddStatusText("Australia highlight = " + recvHighlight + ", lastrec=" + lastReceiveTime + ", lastsend=" + lastSendTime);
                } */
                if (recvHighlight < 10 || sendHighlight < 10) {
                    ListViewItem lvi = new ListViewItem(new string[] {
                        country.getShortName(), country.getShortName(), country.getShortName()
                        /*Convert.ToString(sendHighlight), Convert.ToString(recvHighlight)*/ }, -1);
                    lvi.ImageIndex = country.getFlagIndex();
                    sideListView.Items.Add(lvi);
                    sideListMaxSend = Math.Max(sideListMaxSend, country.getMaxSendBytes());
                    sideListMaxRecv = Math.Max(sideListMaxSend, country.getMaxRecvBytes());
            
                    // show country
                    LngLat min = country.getMinLngLat();
                    LngLat max = country.getMaxLngLat();
                    objGraphics.DrawImage(country.getImage(), 
                        (int)((min.getLng() - baseCountry.getMinLngLat().getLng()) * 8),
                        (int)((min.getLat() - baseCountry.getMinLngLat().getLat()) * 8));

                    /*
                    this.AddStatusText(String.Format("Drawing ({0},{1}) -> ({2},{3}) {4}", 
                        (int) ((min.getLng()-baseCountry.getMinLngLat().getLng()) * 8), 
                        (int) ((min.getLat()-baseCountry.getMinLngLat().getLat()) * 8),
                        (int) ((max.getLng()-min.getLng()) * 8), 
                        (int) ((max.getLat()-min.getLat()) * 8), country.getName()));
                    */
                }
            }
            sideListView.EndUpdate();

            _refreshTime = "Refresh time: " + ((DateTime.Now - now).TotalMilliseconds) + "ms";
            spbImage.BackingImage = bitmap;
        }

        // really belongs in a separate class, but needs access to data contained here
        public void PaintOverlay(PaintEventArgs e) {
            Graphics g = e.Graphics;
            _refreshTime = "clientSize: " + spbImage.ClientSize.Width + "x" + spbImage.ClientSize.Height + ", " +
                "backingImage: " + spbImage.BackingImage.Width + "x" + spbImage.BackingImage.Height + ", " +
                "pictureBox: " + spbImage.PictureBox.Width + "x" + spbImage.PictureBox.Height + ", " +
                "intloc: " + spbImage.InternalLocation.X + "x" + spbImage.InternalLocation.Y + ", ";

            Font font = new Font("Arial", 8);
            Brush brush = new SolidBrush(Color.LightBlue);
            g.DrawString( _refreshTime, font, brush, 10, 10);
            DateTime now = DateTime.Now;

            foreach (CountryGif country in countries) {
                double recvHighlight = double.MaxValue;
                double sendHighlight = double.MaxValue;
                DateTime lastReceiveTime = country.getLastReceiveTime();
                DateTime lastSendTime = country.getLastSendTime();
                if (lastReceiveTime != null) {
                    TimeSpan duration = now - lastReceiveTime;
                    recvHighlight = (int)duration.TotalSeconds;
                }
                if (lastSendTime != null) {
                    TimeSpan duration = now - lastSendTime;
                    sendHighlight = (int)duration.TotalSeconds;
                }
                if (recvHighlight < 10 || sendHighlight < 10) {
                    // show country
                    float zoom = ((float)spbImage.ScalePercent);

                    LngLat min = country.getMinLngLat();
                    LngLat max = country.getMaxLngLat();
                    Color col = Color.FromArgb(
                        sendHighlight < 10 ? 255 - (int)(sendHighlight * 10) : 0,
                        recvHighlight < 10 ? 255 - (int)(recvHighlight * 10) : 0, 0);
                    int x = spbImage.InternalLocation.X + (int)((min.getLng() - baseCountry.getMinLngLat().getLng()) * 8 * zoom);
                    int y = spbImage.InternalLocation.Y + (int)((min.getLat() - baseCountry.getMinLngLat().getLat()) * 8 * zoom);
                    this.drawBorder(g, col, x, y,
                        (int)((max.getLng() - min.getLng()) * 8 * zoom),
                        (int)((max.getLat() - min.getLat()) * 8 * zoom));
                    List<CountryIp> countryIps = country.getCountryIps();
                    // g.DrawString("" + countryIps.Count + " ips", font, Brushes.White, x - 50, y -10);

                    int ipCount = Math.Min(countryIps.Count, 5);
                    int h = 10 * ipCount + 18;
                    Bitmap b = new Bitmap(85, h, PixelFormat.Format32bppArgb);
                    Graphics g2 = Graphics.FromImage(b);
                    g2.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 249, 199)), 0,0,85,h);

                    g2.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 249, 199)), 0,0,85,12);
                    g2.FillRectangle(new SolidBrush(Color.FromArgb(100, 255, 249, 199)), 0,h-2,85, 2);
                    g2.DrawLine(new Pen(Color.FromArgb(100, 255, 249, 199)), 0, 0, 0, h);
                    g2.DrawLine(new Pen(Color.FromArgb(100, 255, 249, 199)), 85, 0, 85, h);

                    g2.DrawString(country.getName(), font, Brushes.Yellow, 2, -1);
                    for (int i = 0; i < ipCount; i++) {
                        int width = (int) g.MeasureString(countryIps[i].getIp(), font).Width;
                        g2.DrawString(countryIps[i].getIp(), font, Brushes.White, 2, 13 + i * 10);
                    }
                    g2.Dispose();

                    // x-width-10
                    g.DrawImage(b, x - 85 - 10, y);
                    b.Dispose();

                }
            }
        }


        private void drawBorder(Graphics g, Color c, int x, int y, int width, int height) {
            Brush brush = new SolidBrush(c);
            int margin = 8;
            int thickness = 2;
            int length = 15;

            g.FillRectangle(brush, x - margin, y - margin, thickness, length);
            g.FillRectangle(brush, x - margin, y - margin, length, thickness);  // overlap here
            g.FillRectangle(brush, x - margin, y + height + margin - length, thickness, length);
            g.FillRectangle(brush, x - margin, y + height + margin - thickness, length, thickness);
            g.FillRectangle(brush, x + width + margin - length, y - margin, length, thickness);
            g.FillRectangle(brush, x + width + margin - thickness, y - margin, thickness, length);
            g.FillRectangle(brush, x + width + margin - thickness, y + height + margin - length, thickness, length);
            g.FillRectangle(brush, x + width + margin - length, y + height + margin - thickness, length, thickness);
        }

        // never appears to fire
        private void spbImage_MouseMove(object sender, MouseEventArgs e) {
            AddStatusText("Mouse moved: " + e.X + ", " + e.Y);
        }


        /** side list */
        // Selects and focuses an item when it is clicked anywhere along 
        // its width. The click must normally be on the parent item text.
        private void sideListView_MouseUp(object sender, MouseEventArgs e) {
            ListViewItem clickedItem = sideListView.GetItemAt(5, e.Y);
            if (clickedItem != null) {
                clickedItem.Selected = true;
                clickedItem.Focused = true;
            }
        }

        // Draws the backgrounds for entire ListView items.
        private void sideListView_DrawItem(object sender,
            DrawListViewItemEventArgs e) {
            if ((e.State & ListViewItemStates.Selected) != 0) {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), e.Bounds);
                e.DrawFocusRectangle();
            } else {
                // Draw the background for an unselected item.
                /*
                using (LinearGradientBrush brush =
                    new LinearGradientBrush(e.Bounds, Color.Orange,
                    Color.Maroon, LinearGradientMode.Horizontal)) {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }*/
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
            }

            // Draw the item text for views other than the Details view.
            if (sideListView.View != View.Details) {
                e.DrawText();
            }
        }

        // Draws subitem text and applies content-based formatting.
        private void sideListView_DrawSubItem(object sender,
            DrawListViewSubItemEventArgs e) {
            TextFormatFlags flags = TextFormatFlags.Left;

            using (StringFormat sf = new StringFormat()) {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign) {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                // Draw the text and background for a subitem with a 
                // negative value. 
                /*
                double subItemValue;
                if (e.ColumnIndex > 0 && Double.TryParse(
                    e.SubItem.Text, NumberStyles.Currency,
                    NumberFormatInfo.CurrentInfo, out subItemValue) &&
                    subItemValue < 0) {
                    // Unless the item is selected, draw the standard 
                    // background to make it stand out from the gradient.
                    if ((e.ItemState & ListViewItemStates.Selected) == 0) {
                        e.DrawBackground();
                    }

                    // Draw the subitem text in red to highlight it. 
                    e.Graphics.DrawString(e.SubItem.Text,
                        sideListView.Font, Brushes.Red, e.Bounds, sf);

                    return;
                }
                 */

                // Draw normal text for a subitem with a nonnegative 
                // or nonnumerical value.
                CountryGif countryGif = (CountryGif)countryMap[e.SubItem.Text];

                if (countryGif == null) {
                    // e.Graphics.FillRectangle(new SolidBrush(Color.Green), e.Bounds);
                    e.DrawText(flags);
                } else {
                    if (e.ColumnIndex == 0) {
                        int flagIndex = countryGif.getFlagIndex();
                        if (flagIndex != -1) {
                            e.Graphics.DrawImage(sideListView.SmallImageList.Images[flagIndex], e.Bounds.Left, e.Bounds.Top);
                        }
                        e.Graphics.DrawString(countryGif.getName(), sideListView.Font, Brushes.Black, e.Bounds.Left+20, e.Bounds.Top);

                    } else if (e.ColumnIndex == 1) {
                        e.Graphics.DrawImage(countryGif.getSendImage(e.Bounds.Width, e.Bounds.Height, sideListMaxSend), e.Bounds.Left, e.Bounds.Top);
                    } else if (e.ColumnIndex == 2) {
                        e.Graphics.DrawImage(countryGif.getReceiveImage(e.Bounds.Width, e.Bounds.Height, sideListMaxRecv), e.Bounds.Left, e.Bounds.Top);
                    } else {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                    }
                }
                // e.DrawText(flags);
            }
        }

        // Draws column headers.
        private void sideListView_DrawColumnHeader(object sender,
            DrawListViewColumnHeaderEventArgs e) {
            using (StringFormat sf = new StringFormat()) {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign) {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont = new Font("Tahoma", 8, FontStyle.Regular)) {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }

        // Forces each row to repaint itself the first time the mouse moves over 
        // it, compensating for an extra DrawItem event sent by the wrapped 
        // Win32 control.
        private void sideListView_MouseMove(object sender, MouseEventArgs e) {
            ListViewItem item = sideListView.GetItemAt(e.X, e.Y);
            if (item != null) {
                if (item.Tag == null) {
                    sideListView.Invalidate(item.Bounds);
                    item.Tag = "tagged";
                    // Console.WriteLine("now tagged");
                } else {
                    // Console.WriteLine("was already " + item.Tag);
                }
            }
        }

        private void cmdCheckUpdatesAtStartup_Click(object sender, EventArgs e) {
            autoUpdate = !autoUpdate;
            cmdCheckUpdatesAtStartup.Checked = autoUpdate;
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Randomnoun\\Packetmap", true);
            // If the return value is null, the key doesn't exist
            if (key == null) {
                key = Registry.CurrentUser.CreateSubKey("Software\\Randomnoun\\Packetmap");
            }
            key.SetValue("AutoUpdate", autoUpdate ? 1 : 0);
            key.Close();
            
        }

        private void cmdCheckUpdatesNow_Click(object sender, EventArgs e) {
            checkForUpdatesNow(false);
        }

        private void checkForUpdatesNow(bool fromSplash) {
            string text = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://packetmap.sourceforge.net/currentBuild.txt");
            try {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK) {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream, Encoding.ASCII);
                    String responseHtml = reader.ReadToEnd();
                    response.Close();
                    string[] lines = responseHtml.Split(new char[] { '\n' });
                    Hashtable responseMap = new Hashtable();
                    for (int i = 0; i < lines.Length; i++) {
                        if (lines[i].IndexOf("=") != -1) {
                            responseMap[lines[i].Substring(0, lines[i].IndexOf("=")).Trim()] =
                                lines[i].Substring(lines[i].IndexOf("=") + 1).Trim();
                        }
                    }
                    if (responseMap.ContainsKey("Version") && responseMap.ContainsKey("DownloadUrl") && !responseMap["Version"].Equals(MainProgram.VERSION)) {
                        if (MessageBox.Show(
                          "You are currently running version " + MainProgram.VERSION + " of Packetmap. " +
                          "There is a new version (" + responseMap["Version"] + ") of PacketMap available. " +
                          "Would you like to download and install this new version ? ",
                          "New version available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                            // go to window and exit
                            bool success = false;
                            try {
                                System.Diagnostics.Process.Start((string)responseMap["DownloadUrl"]);
                                success = true;
                            } catch (Win32Exception noBrowser) {
                                if (noBrowser.ErrorCode == -2147467259)
                                    MessageBox.Show(noBrowser.Message);
                            } catch (System.Exception other) {
                                MessageBox.Show(other.Message);
                            }
                            if (success) {
                                // only close app if page retrieval was a success
                                Application.Exit();
                            }
                        }
                    }
                } else {
                    
                    text = "Response not received: " + response.StatusDescription + "(" + response.StatusCode + ")";
                }
            } catch (WebException wre) {
                text = "Error: " + wre.Message + "(" + wre.Response + ")";
            }
            if (fromSplash) {
                Console.WriteLine(text);
            } else {
                MessageBox.Show(text, "Update check response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }

}
