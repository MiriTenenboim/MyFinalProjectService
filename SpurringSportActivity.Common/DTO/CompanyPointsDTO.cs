using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Common.DTO
{
    public class CompanyPointsDTO
    {
        // קוד נקודה חברה
        public int CompanyPointId { get; set; }
        // קוד חברה
        public int CompanyId { get; set; }
        public CompaniesDetailsDTO? Company { get; set; }
        // קוד קופון
        public int CouponId { get; set; }
        public CouponDetailsDTO? Coupon { get; set; }

        public CompanyPointsDTO(int companyId, CompaniesDetailsDTO company, int couponId, CouponDetailsDTO coupon)
        {
            CompanyId = companyId;
            Company = company;
            CouponId = couponId;
            Coupon = coupon;
        }
    }
}
