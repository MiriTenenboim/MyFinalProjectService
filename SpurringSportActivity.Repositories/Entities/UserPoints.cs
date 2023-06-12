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
    public class UserPoints
    {
        [Key]
        // קוד נקודה של לקוח
        public int UserPointId { get; set; }
        // קוד לקוח
        public int UserId { get; set; }
        public UsersDetails? User { get; set; }
        // סכום הקופון
        public int CouponAmount { get; set; }
        // תאריך יעד
        public DateTime DueDate { get; set; }
    }
}
