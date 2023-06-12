using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Interfaces
{
    public interface IUsersDetailsRepository
    {
        // שליפת כל המשתמשים
        Task<List<UsersDetails>> GetAllUsersAsync();
        // שליפת משתמש לפי קוד
        Task<UsersDetails> GetUserByIdAsync(int id);
        // הוספת משתמש
        Task<UsersDetails> AddUserAsync(UsersDetails userDetails);
        // עדכון משתמש
        Task<UsersDetails> UpdateUserAsync(UsersDetails userDetails);
        // שליפת משתמש לפי שם וסיסמה
        Task<UsersDetails> GetUserByNamePasswordAsync(string userName, string password);
    }
}
