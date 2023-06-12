using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpurringSportActivity.Repositories.Repositories
{
    public class UsersDetailsRepository : IUsersDetailsRepository
    {
        private readonly IContext _context;

        public UsersDetailsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<UsersDetails> AddUserAsync(UsersDetails userDetails)
        {
            var addedUser = await _context.UsersDetails.AddAsync(userDetails);
            await _context.SaveChangesAsync();
            return addedUser.Entity;
        }

        public async Task<UsersDetails> UpdateUserAsync(UsersDetails userDetails)
        {
            //UsersDetails user = _context.UsersDetails.FindAsync(userDetails.UserId).Result;
            //user.UserFirstName = userDetails.UserFirstName;
            //user.UserLastName = userDetails.UserLastName;
            //user.UserName = userDetails.UserName;
            //user.UserEmailAddress = userDetails.UserEmailAddress;
            //user.UserPassword = userDetails.UserPassword;
            //user.UserBank = userDetails.UserBank;
            //user.UserBankBranch = userDetails.UserBankBranch;
            //user.UserBankAccount = userDetails.UserBankAccount;
            var updatedUser = _context.UsersDetails.Update(userDetails);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }

        public async Task<List<UsersDetails>> GetAllUsersAsync()
        {
            return await _context.UsersDetails.ToListAsync();
        }

        public async Task<UsersDetails> GetUserByIdAsync(int id)
        {
            return await _context.UsersDetails.FindAsync(id);
        }

        public async Task<UsersDetails> GetUserByNamePasswordAsync(string userName, string password)
        {
            var user = await _context.UsersDetails.FirstOrDefaultAsync(user => (user.UserName == userName) && (user.UserPassword == password));
            return (user != null) ? user : null;
        }
    }
}
