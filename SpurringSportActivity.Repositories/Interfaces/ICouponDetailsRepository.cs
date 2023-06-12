using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Interfaces
{
    public interface ICouponDetailsRepository
    {
        // שליפת כל הקופונים
        Task<List<CouponDetails>> GetAllCouponDetailsAsync();
        // שליפת קופון לפי קוד
        Task<CouponDetails> GetCouponDetailsAsync(int id);
        // הוספת קופון
        Task<CouponDetails> AddCouponDetailsAsync(CouponDetails couponDetails);
    }
}
