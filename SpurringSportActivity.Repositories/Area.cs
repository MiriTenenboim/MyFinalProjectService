using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories
{
    public class Area
    {
        // ארבעת הקודקודים של האזור המבוקש
        public double vertex1X { get; set; }
        public double vertex1Y { get; set; }
        public double vertex2X { get; set; }
        public double vertex2Y { get; set; }

        public Area(double vertex1X, double vertex2X, double vertex1Y, double vertex2Y)
        {
            this.vertex1X = vertex1X;           
            this.vertex2X = vertex2X;
            this.vertex1Y = vertex1Y;
            this.vertex2Y = vertex2Y;
        }
    }
}
