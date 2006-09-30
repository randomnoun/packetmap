using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsApplication1
{
    public class TestForm : Form {
        List<Country> countries;

        public TestForm() {
            this.Paint += new PaintEventHandler(f1_paint);
        }

        private void f1_paint(object sender, PaintEventArgs e) {

            // Get Graphics Object
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.Black), g.VisibleClipBounds);

            // Method under System.Drawing.Graphics
            //g.DrawString("Welcome C#", new Font("Verdana", 20),
            //new SolidBrush(Color.Tomato), 40, 40);

            // also g.FillPolygon

            List<LngLat> outline;
            for (int j = 0; j < polys.Count; j++) {
                outline = polys[j];
                Point[] pts = new Point[outline.Count - 1];
                for (int i = 1; i < outline.Count; i++) {  // 0th lnglat is inside poly
                    LngLat lngLat = outline[i];
                    pts[i - 1] = new Point(Convert.ToInt32(lngLat.getLng() * 8 + 1200), Convert.ToInt32(lngLat.getLat() * 8 - 300));
                    // Console.WriteLine("pts[" + i + "]=" + pts[i].X + ", " + pts[i].Y); 
                }
                // Console.WriteLine("count=" + outline.Count);
                // g.DrawPolygon(new Pen(Color.LightGreen, 1), pts);
                g.FillPolygon(new SolidBrush(Color.LightGreen), pts);
            }
        }

        public static void Main() {
            TestForm testForm = new TestForm();
            testForm.loadData();
            Application.Run(testForm);
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

    public class Country {
        List<List<LngLat>> polys;

        public Country() {
            polys = new List<List<LngLat>>();
        }

        public void loadData(String file)
        {

            // polys = new List<List<LngLat>>();
            // Open the file and read it back.
            using (System.IO.StreamReader sr = System.IO.File.OpenText(file))
            {
                string s = "";
                string country = sr.ReadLine();
                long polyNum = long.Parse(sr.ReadLine());
                List<LngLat> poly = new List<LngLat>();
                polys.Add(poly);
                Boolean eof = false;
                while ((!eof) && (s = sr.ReadLine()) != null)
                {
                    s = s.Trim();
                    if (s.Equals("")) {
                        // ignore
                    } else if (s.StartsWith("END"))
                    {
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
                    }
                    else
                    {
                        Match m = Regex.Match(s, "\\s*([0-9-.]*)\\s*([0-9-.]*)");
                        double lng, lat;
                        if (m.Success)
                        {
                            lng = Convert.ToDouble(m.Groups[1].Value);
                            lat = Convert.ToDouble(m.Groups[2].Value);
                            poly.Add(new LngLat(lng, lat));
                        }
                        else
                        {
                            throw new ArgumentException("In file '" + file + "': Invalid string '" + s + "'");
                        }
                    }
                }
            }
        }
    }




}
