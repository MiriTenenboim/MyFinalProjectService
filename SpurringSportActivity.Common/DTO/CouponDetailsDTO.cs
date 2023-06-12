using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Common.DTO
{
    public class CouponDetailsDTO
    {
        // קוד קופון
        public int CouponId { get; set; }
        // פרטי קופון
        public int CouponDetail { get; set; }
        // פרסומת חברה
        public string Advertisement { get; set; }

        public CouponDetailsDTO(int couponDetail, string advertisement)
        {
            CouponDetail = couponDetail;
            Advertisement = advertisement;
        }
    }
}
