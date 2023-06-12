using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Interfaces
{
    public interface ICouponDetailsService
    {
        // שליפת כל הקופונים
        Task<List<CouponDetailsDTO>> GetAllCouponDetailsAsync();
        // שליפת קופון לפי קוד
        Task<CouponDetailsDTO> GetCouponDetailsAsync(int id);
        // הוספת קופון
        Task<CouponDetailsDTO> AddCouponDetailsAsync(CouponDetailsDTO couponDetails);
    }
}
