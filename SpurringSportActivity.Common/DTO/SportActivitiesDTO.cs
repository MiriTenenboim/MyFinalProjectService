using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Common.DTO
{
    public class SportActivitiesDTO
    {
        //  קוד פעילות ספורט
        public int ActivityId { get; set; }
        // קוד משתמש
        public int UserId { get; set; }
        public UsersDetailsDTO? User { get; set; }
        // תאריך יציאה
        public DateTime? StartDate { get; set; }
        // שעת יציאה
        //public TimeOnly StartTime { get; set; }
        // תאריך חזרה
        public DateTime? CompletionDate { get; set; }
        // שעת חזרה
        //public TimeOnly CompletionTime { get; set; }
        // מספר הקילומטרים שצעד
        public float TotalKilometers { get; set; }
        // מספר הצעדים שצעד
        public int TotalSteps { get; set; }

    }
}
