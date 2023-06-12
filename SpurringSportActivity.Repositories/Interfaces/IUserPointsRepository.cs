using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Interfaces
{
    public interface IUserPointsRepository
    {
        // הוספת נקודה למשתמש
        Task<UserPoints> AddUserPointAsync(UserPoints userPoint);
        // שליפת נקודה למשתמש
        Task<List<UserPoints>> GetUserPointsAsync(int id);
        // שליפת נקודה לפי תאריך יעד
        Task<UserPoints> GetUserPointByDueDateAsync(int id,DateTime dueDate);
    }
}
