using System;
using System.Collections.Generic;
using System.Text;

namespace PacketMap {
    /// <summary>
    /// Stores longitude/latitude data, as doubles
    /// </summary>
    public class LngLat {
        double lng;
        double lat;
        public LngLat(double lng, double lat) {
            this.lng = lng;
            this.lat = lat;
        }
        // TODO: should have used properties
        public double getLng() { return lng; }
        public double getLat() { return lat; }
    }
}
