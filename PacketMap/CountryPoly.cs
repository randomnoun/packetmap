using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace PacketMap {

    /// <summary>
    /// A definition of a country, define as a collection of vector polygons. This
    /// representation is only used when loading vector data and saving as rasters
    /// (this seems to run a lot faster than painting polys directly. Although
    /// I'm sure using DirectX would probably give a good response time). Perhaps
    /// cutting down the number of points stored for each country would be a 
    /// step in the right direction.
    /// </summary>
    public class CountryPoly {

        /// <summary>
        /// List of polygons (each poly represented as a List of LngLats)
        /// </summary>
        List<List<LngLat>> polys;
        Image image = null;

        /// <summary>
        /// Create a new CountryPoly
        /// </summary>
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

        public Image getImage(Color foreColor, Color backColor) {
            if (image != null) {
                return image;
            }

            LngLat minLngLat = getMinLngLat();
            LngLat maxLngLat = getMaxLngLat();
            double width = maxLngLat.getLng() - minLngLat.getLng();
            double height = maxLngLat.getLat() - minLngLat.getLat();

            // render to image Convert.ToInt32
            // max is required for Africa/Tromelin Island
            image = new Bitmap(Math.Max(Convert.ToInt32(width * 8), 1), Math.Max(Convert.ToInt32(height * 8), 1), PixelFormat.Format32bppArgb);
            Graphics offScreenDC = Graphics.FromImage(image);
            drawCountry(offScreenDC, foreColor, backColor);
            offScreenDC.Dispose();
            return image;
        }

        public void saveToFile(String file, Color foreColor, Color backColor) {
            Image image = getImage(foreColor, backColor);
            image.Save(file, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void drawCountry(Graphics g, Color foreColor, Color backColor) {
            g.FillRectangle(new SolidBrush(backColor), g.VisibleClipBounds);

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
                    pts[i - 1] = new Point(Convert.ToInt32((lngLat.getLng() - minLngLat.getLng()) * 8),
                          Convert.ToInt32((lngLat.getLat() - minLngLat.getLat()) * 8));
                    // Console.WriteLine("pts[" + i + "]=" + pts[i].X + ", " + pts[i].Y); 
                }
                // Console.WriteLine("count=" + outline.Count);
                // g.DrawPolygon(new Pen(Color.LightGreen, 1), pts);
                g.FillPolygon(new SolidBrush(foreColor), pts);
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
