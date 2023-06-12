using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Entities
{
    public class CompanyPoints
    {
        [Key]
        // קוד נקודה חברה
        public int CompanyPointId { get; set; }
        // קוד חברה
        public int CompanyId { get; set; }
        public CompaniesDetails? Company { get; set; } = null;
        // קוד קופון
        [DefaultValue(null)]
        public int CouponId { get; set; }        
        public CouponDetails? Coupon { get; set; }
    }
}
