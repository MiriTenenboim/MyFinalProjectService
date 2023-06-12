using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Interfaces
{
    public interface IUserPointsService
    {
        // הוספת נקודה למשתמש
        Task<UserPointsDTO> AddUserPointAsync(UserPointsDTO userPoints);
        // שליפת נקודה למשתמש
        Task<List<UserPointsDTO>> GetUserPointsAsync(int id);
        // שליפת נקודה לפי תאריך יעד
        Task<UserPointsDTO> GetUserPointByDueDateAsync(int id,DateTime dueDate);
    }
}
