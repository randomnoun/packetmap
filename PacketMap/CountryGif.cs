using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace PacketMap {

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
        public static int MAX_HISTORY = 40;   /* number of ticks of send/recv byte count data */
        public static int MAX_IPS = 10;
        
        // dimensions
        LngLat minLngLat;
        LngLat maxLngLat;
        Image image;
        String name;
        int flagIndex;  // index into flag imageList
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
        public void setFlagIndex(int flagIndex) { this.flagIndex = flagIndex; }
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

        public DateTime getLastReceiveTime() { return lastReceiveTime; }
        public DateTime getLastSendTime() { return lastSendTime; }
        public int getFlagIndex() { return flagIndex; }

        public Image getSendImage(int width, int height, long scale) {
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
        public Image getReceiveImage(int width, int height, long scale) {
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
