using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Entities
{
    public enum EStatus { User, Company }

    public class PointsDetails
    {
        [Key]
        // קוד נקודה
        public int PointId { get; set; }
        // נקודה X
        public float PointX { get; set; }
        // נקודה Y
        public float PointY { get; set; }
        // קוד לקוח - אם זה לקוח
        public int UserPointId { get; set; }
        public UserPoints? UserPoint { get; set; }
        // קוד חברה - אם זה חברה
        public int CompanyPointId { get; set; }
        public CompanyPoints? CompanyPoint { get; set; }
        // האם זה לקוח / חברה
        public EStatus UserOrCompany { get; set; }
        // האם הנקודה מומשה
        public bool IsRealized { get; set; }
        // תאריך הנחה
        public DateTime PlacingDate { get; set; }
        // תאריך זכיה
        [AllowNull]
        public DateTime? DateWon { get; set; }
        // קוד לקוח זוכה
        public int WinningUserId { get; set; }
        public UsersDetails WinningUser { get; set; }
    }
}
