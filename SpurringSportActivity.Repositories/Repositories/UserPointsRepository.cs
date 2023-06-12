using Microsoft.EntityFrameworkCore;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Repositories
{
    public class UserPointsRepository : IUserPointsRepository
    {
        private readonly IContext _context;
        private readonly IPublicPointsRepository _publicPointsRepository;
        private static ConcurrentDictionary<string, Task<string>> timers = new ConcurrentDictionary<string, Task<string>>();
        int totalSeconds;


        public UserPointsRepository(IContext context, IPublicPointsRepository publicPointsRepository)
        {
            _context = context;
            _publicPointsRepository = publicPointsRepository;
        }

        public async Task<UserPoints> AddUserPointAsync(UserPoints userPoint)
        {
            if (userPoint.User != null)
            {
                _context.UsersDetails.Attach(userPoint.User);
            }
            var addedUser = await _context.UserPoints.AddAsync(userPoint);
            await _context.SaveChangesAsync();
            return addedUser.Entity;
        }

        public async Task<List<UserPoints>> GetUserPointsAsync(int id)
        {
            var userPoint = await _context.UserPoints.Include(userPoint => userPoint.User).Where(userPoint => userPoint.UserId == id).ToListAsync();
            return userPoint;
        }

        public async Task<UserPoints> GetUserPointByDueDateAsync(int id, DateTime dueDate)
        {
            return await _context.UserPoints.FirstOrDefaultAsync(userPoint => (userPoint.UserId == id)&&(userPoint.DueDate.Date == dueDate.Date));
        }
    }
}
