using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Common.DTO
{
    public class UserPointsDTO
    {
        public int UserPointId { get; set; }
        // קוד לקוח
        public int UserId { get; set; }
        public UsersDetailsDTO? User { get; set; }
        // סכום הקופון
        public int CouponAmount { get; set; }
        // תאריך יעד
        public DateTime DueDate { get; set; }

        public UserPointsDTO() { }

        public UserPointsDTO(int couponAmount)
        {
            CouponAmount = couponAmount;
        }

        public UserPointsDTO(int userId, UsersDetailsDTO user, int couponAmount, DateTime dueDate)
        {
            UserId = userId;
            User = user;
            CouponAmount = couponAmount;
            DueDate = dueDate;
        }
    }
}
