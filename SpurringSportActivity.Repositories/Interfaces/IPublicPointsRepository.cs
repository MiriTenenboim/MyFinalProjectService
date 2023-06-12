using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Interfaces
{
    public interface IPublicPointsRepository
    {
        // הוספת נקודה ציבורית
        Task<PublicPoints> AddPublicPointAsync(PublicPoints publicPoint);
        // שליפת כל הנקודות שעדיין לא מומשו
        Task<List<PublicPoints>> GetAllNotRealizedPoints(Area area);
        // שליפת כל הנקודות
        Task<List<PublicPoints>> GetAllPublicPoints();
    }
}
