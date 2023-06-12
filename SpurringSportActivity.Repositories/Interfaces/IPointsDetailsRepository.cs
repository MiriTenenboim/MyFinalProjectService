using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Interfaces
{
    public interface IPointDetailsRepository
    {
        // הוספת פרטי נקודה
        Task<PointsDetails> AddPointDetailsAsync(PointsDetails pointDetails);
        // עדכון הנקודה למומשה
        //Task<PointsDetails> UpdatePointToRealizedAsync(PointsDetails pointDetails);
        // שליפת פרטי הנקודות שמומשו למשתמש מסוים
        Task<List<PointsDetails>> GetRealizedPointsAsync(int id);
        // שליפת פרטי נקודה לפי קוד
        Task<PointsDetails> GetPointByIdAsync(int id);
        // עדכון נקודה שמומשה
        Task<PointsDetails> UpdateRealizedPointAsync(int id,int userId);
        // עדכון פרטי נקודה
        Task<PointsDetails> UpdatePointAsync(PointsDetails pointDetails);
        // מחיקת נקודה
        Task<PointsDetails> DeletePointAsync(PointsDetails pointDetails);
        // שליפת כל הנקודות
        Task<List<PointsDetails>> GetAllPointsAsync();
        // שליפת הנקודות שהחברה הציבה
        Task<List<PointsDetails>> GetPointsByIdAsync(int userOrCompany, int id);
        // שליפת נקודה לפי קוד נקודה
        Task<PointsDetails> GetPointByPointIdAsync(int userOrCompany, int id);
    }
}
