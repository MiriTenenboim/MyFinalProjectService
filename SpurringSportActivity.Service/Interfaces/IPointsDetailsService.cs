using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Interfaces
{
    public interface IPointDetailsService
    {
        // הוספת פרטי נקודה
        Task<PointDetailsDTO> AddPointDetailsAsync(PointDetailsDTO pointsDetails);
        // שליפת פרטי הנקודות שמומשו למשתמש מסוים
        Task<List<PointDetailsDTO>> GetRealizedPointsAsync(int id);
        // עדכון פרטי נקודה
        Task<PointDetailsDTO> UpdateRealizedPointAsync(int id, int userId);
        // עדכון פרטי נקודה
        Task<PointDetailsDTO> UpdatePointAsync(PointDetailsDTO pointDetails);
        // מחיקת נקודה
        Task<PointDetailsDTO> DeletePointAsync(PointDetailsDTO pointDetails);
        // שליפת כל הנקודות
        Task<List<PointDetailsDTO>> GetAllPointsAsync();
        // שליפת הנקודות שהחברה הציבה
        Task<List<PointDetailsDTO>> GetPointsByIdAsync(int userOrCompany, int id);
    }
}
