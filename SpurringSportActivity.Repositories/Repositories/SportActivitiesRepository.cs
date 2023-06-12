 using Microsoft.EntityFrameworkCore;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Repositories
{
    public class SportActivitiesRepository : ISportActivitiesRepository
    {
        private readonly IContext _context;

        public SportActivitiesRepository(IContext context)
        {
            _context = context;
        }

        public async Task<SportActivities> AddSportActivityAsync(SportActivities sportActivity)
        {
            var added = await _context.SportsActivities.AddAsync(sportActivity);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<List<SportActivities>> GetSportActivitiesByIdAsync(int id)
        {
            return await _context.SportsActivities.Where(user=>user.UserId == id).ToListAsync();
        }

        public async Task<SportActivities> UpdateSportActivityAsync(SportActivities sportActivity)
        {
            var updateSportActivity = _context.SportsActivities.Update(sportActivity);
            await _context.SaveChangesAsync();
            return updateSportActivity.Entity;
        }
    }
}
