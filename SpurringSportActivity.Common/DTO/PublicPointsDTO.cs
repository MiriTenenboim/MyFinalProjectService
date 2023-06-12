using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Common.DTO
{
    public class PublicPointDTO
    {
        // קוד נקודה ציבורית
        public int PublicPointId { get; set; }
        // קוד נקודה
        public int PointId { get; set; }
        public PointDetailsDTO Point { get; set; }

        public PublicPointDTO(int pointId)
        {
            PointId = pointId;
        }

        public PublicPointDTO(PointDetailsDTO point)
        {
            Point = point;
        }
    }
}
