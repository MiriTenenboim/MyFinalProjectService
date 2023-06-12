using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Entities
{
    public class CouponDetails
    {
        [Key]
        // קוד קופון
        public int CouponId { get; set; }
        // פרטי קופון
        public int CouponDetail { get; set; }
        // פרסומת חברה
        public string Advertisement { get; set; }
    }
}
