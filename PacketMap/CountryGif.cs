using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace PacketMap {

    /// <summary>
    /// Class used to keep track of IP addresses within each country; the last 
    /// few IPs are displayed on the map next to that country (eventually this
    /// will show domains/URLs, but it's just dotted notation at the moment).
    /// </summary>
    public class CountryIp {
        string ip;
        DateTime lastActivity;
        public CountryIp(string ip, DateTime lastActivity) {
            this.ip = ip;
            this.lastActivity = lastActivity;
        }
        public string getIp() { return ip; }
        public DateTime getLastActivity() { return lastActivity; }
        public void setLastActivity() { this.lastActivity = DateTime.Now; }
    }
    
    /// <summary>
    /// The definition of a country, defined as a raster image
    /// </summary>
    public class CountryGif {

        /// <summary>number of ticks of send/recv byte count data</summary>
        public static int MAX_HISTORY = 40;

        /// <summary>number of IPs to keep track of in each country</summary>
        public static int MAX_IPS = 10;

        /// <summary>location of the bottom-left corner of this country's bounding box</summary>
        LngLat minLngLat;

        /// <summary>location of the top-right corner of this country's bounding box</summary>
        LngLat maxLngLat;

        /// <summary>Raster image of the country, to be used on the global map</summary>
        Image image;

        /// <summary>English name of the country</summary>
        String name;

        public int flagIndex = -1, flagX, flagY, flagWidth, flagHeight;  // index into flag imageList

        /// <summary>ISO country code of this country</summary>
        private string shortName;

        // pixel positions
        public int positionIdx;    // index into positions array
        public List<Point> positions = new List<Point>(); // possible positions
        public Image overlay;

        // dynamic data
        DateTime lastReceiveTime = DateTime.Now;  // last time we received from this country
        DateTime lastSendTime = DateTime.Now;     // last time we sent to this country

        
        long[] recvHistBytes = new long[MAX_HISTORY];  // updated per animation tick
        long[] sendHistBytes = new long[MAX_HISTORY];  // updated per animation tick (?)
        public double recvHighlight, sendHighlight;

        List<CountryIp> countryIps = new List<CountryIp>(MAX_IPS);
        
        public long getMaxRecvBytes() {
            long v = 0;
            for (int i = 0; i < MAX_HISTORY; i++) { if (recvHistBytes[i] > v) { v = recvHistBytes[i]; } }
            return v;
        }
        public long getMaxSendBytes() {
            long v = 0;
            for (int i = 0; i < MAX_HISTORY; i++) { if (sendHistBytes[i] > v) { v = sendHistBytes[i]; } }
            return v;
        }
        public void shift() {
            // @TODO could make this more efficient with recv/send above
            for (int i = MAX_HISTORY - 2; i >= 0; i--) {
                recvHistBytes[i + 1] = recvHistBytes[i];
                sendHistBytes[i + 1] = sendHistBytes[i];
            }
            recvHistBytes[0] = 0;
            sendHistBytes[0] = 0;
        }


        public CountryGif(String file, String name, LngLat minLngLat, LngLat maxLngLat) {
            image = Image.FromFile(file);
            this.name = name;
            this.minLngLat = minLngLat;
            this.maxLngLat = maxLngLat;
        }
        public void setShortName(string shortName) { this.shortName = shortName; }
        public string getShortName() { return shortName; }
        // public void setFlagIndex(int flagIndex) { this.flagIndex = flagIndex; }
        public void setFlagDetails(int flagIndex, int x, int y, int w, int h) {
            this.flagIndex = flagIndex;
            this.flagX = x;
            this.flagY = y;
            this.flagWidth = w;
            this.flagHeight = h;
        }
        public LngLat getMinLngLat() { return minLngLat; }
        public LngLat getMaxLngLat() { return maxLngLat; }
        public Image getImage() { return image; }
        public String getName() { return name; }
        public List<CountryIp> getCountryIps() { return countryIps; }
        public void received(int bytes, string ip) { 
            lastReceiveTime = DateTime.Now; 
            recvHistBytes[0] += bytes;
            refreshIp(ip);
            /*Console.WriteLine(shortName + " recv bytes now " + recvHistBytes[0]);*/ 
        }
        public void sent(int bytes, string ip) { 
            lastSendTime = DateTime.Now; 
            sendHistBytes[0] += bytes;
            refreshIp(ip);
            /*Console.WriteLine(shortName + " recv bytes now " + sendHistBytes[0]);*/ 
        }


        /// <summary>
        /// Update the countryIPs list, which keeps track of the last MAX_IPS IP addresses
        /// in this country we are receiving/sending to. This method is called whenever activity
        /// a packet is received/sent.
        /// </summary>
        /// <param name="ip">IP address, in quad-dotted notation</param>
        private void refreshIp(string ip) {
            CountryIp oldestIp = null, foundIp = null;
            foreach (CountryIp countryIp in countryIps) {
                if (countryIp.getIp().Equals(ip)) { 
                    foundIp = countryIp; break; 
                } else if (oldestIp == null) {
                    oldestIp = countryIp; 
                } else {
                    if (countryIp.getLastActivity().CompareTo(oldestIp.getLastActivity()) < 0) {
                        oldestIp = countryIp;
                    }
                }
            }
            if (foundIp!=null) {
                foundIp.setLastActivity();
            } else {
                if (countryIps.Count == MAX_IPS) {
                    countryIps.Remove(oldestIp);
                }
                countryIps.Add(new CountryIp(ip, DateTime.Now));
            }
        }

        /// <summary>
        /// Returns the time a packet was received from this country
        /// </summary>
        /// <returns>the time a packet was received from this country</returns>
        public DateTime getLastReceiveTime() { return lastReceiveTime; }

        /// <summary>
        /// Returns the time a packet was last sent to this country
        /// </summary>
        /// <returns>the itme a packet was sent to this country</returns>
        public DateTime getLastSendTime() { return lastSendTime; }

        /// <summary>
        /// The index of this country in the MainForm.flagImageList collection
        /// </summary>
        /// <returns>the index of this country in the MainForm.flagImageList collection</returns>
        public int getFlagIndex() { return flagIndex; }

        /// <summary>
        /// Retrieves the send histogram image used in the sideListView for 
        /// this country. 
        /// </summary>
        /// 
        /// <param name="width">width of image, in pixels</param>
        /// <param name="height">height of image, in pixels</param>
        /// <returns></returns>
        public Image getSendImage(int width, int height) {
            Image image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
            long maxSend = getMaxSendBytes();
            if (maxSend > 0) {
                Pen p = new Pen(Color.Red);
                for (int i = 0; i < width; i++) {
                    int y = (int)(sendHistBytes[width - i] * height / maxSend);
                    g.DrawLine(p, i, height - y, i, height);
                }
                p.Dispose();
            }
            g.Dispose();
            return image;
        }


        /// <summary>
        /// Retrieves the receive histogram image used in the sideListView for 
        /// this country. 
        /// </summary>
        /// 
        /// <param name="width">width of image, in pixels</param>
        /// <param name="height">height of image, in pixels</param>
        /// <returns></returns>
        public Image getReceiveImage(int width, int height) {
            Image image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
            long maxRecv = getMaxRecvBytes();
            if (maxRecv > 0) {
                Pen p = new Pen(Color.LightGreen);
                for (int i = 0; i < width; i++) {
                    int y = (int)(recvHistBytes[width - i] * height / maxRecv);
                    g.DrawLine(p, i, height - y, i, height);
                }
                p.Dispose();
            }
            g.Dispose();
            return image;
        }

    }
}
