using SpurringSportActivity.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Interfaces
{
    public interface IUsersDetailsService
    {
        // שליפת כל המשתמשים
        Task<List<UsersDetailsDTO>> GetAllUsersAsync();
        // שליפת משתמש לפי קוד
        Task<UsersDetailsDTO> GetUserByIdAsync(int id);
        // הוספת משתמש
        Task<UsersDetailsDTO> AddUserAsync(UsersDetailsDTO userDetails);
        // עדכון פרטי משתמש
        Task<UsersDetailsDTO> UpdateUserAsync(UsersDetailsDTO userDetails);
        // שליפת משתמש לפי סיסמה
        Task<UsersDetailsDTO> GetUserByNamePasswordAsync(string userName, string password);
    }
}
