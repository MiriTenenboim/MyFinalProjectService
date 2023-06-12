using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Entities
{
    public class PublicPoints
    {
        [Key]
        // קוד נקודה ציבורית
        public int PublicPointId { get; set; }
        // קוד נקודה
        public int PointId { get; set; }
        public PointsDetails Point { get; set; }
    }
}
