using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Common.DTO
{
    public enum EStatus { User, Company }

    public class PointDetailsDTO
    {
        // קוד נקודה
        public int PointId { get; set; }
        // נקודה X
        public double PointX { get; set; }
        // נקודה Y
        public double PointY { get; set; }
        // קוד לקוח - אם זה לקוח
        public int UserPointId { get; set; }
        public UserPointsDTO? UserPoint { get; set; }
        // קוד חברה - אם זה חברה
        public int CompanyPointId { get; set; }
        public CompanyPointsDTO? CompanyPoint { get; set; }
        // האם זה לקוח / חברה
        public EStatus UserOrCompany { get; set; }
        // האם הנקודה מומשה
        public bool IsRealized { get; set; }
        // תאריך הנחה
        public DateTime? PlacingDate { get; set; }
        // תאריך זכיה
        public DateTime? DateWon { get; set; }
        // קוד לקוח זוכה
        public int WinningUserId { get; set; }
        public UsersDetailsDTO? WinningUser { get; set; }

        public PointDetailsDTO() { }

        public PointDetailsDTO(double pointX, double pointY)
        {
            PointX = pointX;
            PointY = pointY;
        }

        public PointDetailsDTO(double pointX, double pointY, int couponAmount)
        {
            PointX = pointX;
            PointY = pointY;
            UserPoint = new UserPointsDTO(couponAmount);
        }
    }
}
