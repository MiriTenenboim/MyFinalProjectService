using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Interfaces
{
    public interface IPublicPointService
    {
        // הוספת נקודה ציבורית
        Task<PublicPointDTO> AddPublicPointAsync(PublicPointDTO publicPoint);
        // שליפת כל הנקודות שעדיין לא מומשו
        Task<List<PublicPointDTO>> GetAllNotRealizedPoints(Area area);
        // שליפת כל הנקודות
        Task<List<PublicPointDTO>> GetAllPublicPoints();
    }
}
