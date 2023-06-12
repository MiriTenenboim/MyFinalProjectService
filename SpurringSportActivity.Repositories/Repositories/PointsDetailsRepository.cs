using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml.Linq;
using System.Collections.Concurrent;

namespace SpurringSportActivity.Repositories.Repositories
{
    public class PointDetailsRepository : IPointDetailsRepository
    {
        private readonly IContext _context;

        public PointDetailsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<PointsDetails> AddPointDetailsAsync(PointsDetails pointDetails)
        {
            var added = await _context.PointsDetails.AddAsync(pointDetails);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<PointsDetails> UpdateRealizedPointAsync(int id, int userId)
        {
            var point = _context.PointsDetails.FindAsync(id).Result;
            if (point != null)
            {
                point.IsRealized = true;
                point.DateWon = DateTime.Now;
                point.WinningUserId = userId;
                var updatedPoint = _context.PointsDetails.Update(point);
                await _context.SaveChangesAsync();
                return updatedPoint.Entity;
            }
            return null;
        }

        public async Task<PointsDetails> GetPointByIdAsync(int id)
        {
            return await _context.PointsDetails.FindAsync(id);
        }

        public async Task<List<PointsDetails>> GetRealizedPointsAsync(int id)
        {
            return await _context.PointsDetails
                .Where(point => (point.WinningUserId == id) && (point.IsRealized == true))
                .Include(point => point.UserPoint)
                .ThenInclude(point => point.User)
                .Include(point => point.CompanyPoint)
                .ThenInclude(point => point.Company)
                .Include(point => point.WinningUser)
                .Include(point => point.CompanyPoint.Coupon)
                .ToListAsync();
        }

        public async Task<List<PointsDetails>> GetAllPointsAsync()
        {
            return await _context.PointsDetails
                .Include(point => point.UserPoint)
                .Include(point => point.CompanyPoint)
                .ToListAsync();
        }

        public async Task<List<PointsDetails>> GetPointsByIdAsync(int userOrCompany, int id)
        {
            if (userOrCompany == 0)
            {
                return await _context.PointsDetails
                  .Include(point => point.UserPoint)
                  .ThenInclude(point => point.User)
                  .Include(point => point.WinningUser)
                  .Where(point => point.UserPoint.UserId == id)
                  .ToListAsync();
            }
            return await _context.PointsDetails
                .Include(point => point.CompanyPoint)
                .ThenInclude(point => point.Company)
                .Include(point => point.WinningUser)
                .Include(point => point.CompanyPoint.Coupon)
                .Where(point => point.CompanyPoint.CompanyId == id)
                .ToListAsync();
        }

        public async Task<PointsDetails> GetPointByPointIdAsync(int userOrCompany, int pointId)
        {
            if (userOrCompany == 0)
            {
                return await _context.PointsDetails
                  .Include(point => point.UserPoint)
                  .ThenInclude(point => point.User)
                  .Include(point => point.WinningUser)
                  .FirstOrDefaultAsync(point => point.UserPointId == pointId);
            }
            return await _context.PointsDetails
                .Include(point => point.CompanyPoint)
                .ThenInclude(point => point.Company)
                .Include(point => point.WinningUser)
                .Include(point => point.CompanyPoint.Coupon)
                .FirstOrDefaultAsync(point => point.CompanyPointId == pointId);
        }

        public async Task<PointsDetails> UpdatePointAsync(PointsDetails pointDetails)
        {
            var updated = _context.PointsDetails.Update(pointDetails);
            await _context.SaveChangesAsync();
            return updated.Entity;
        }

        public async Task<PointsDetails> DeletePointAsync(PointsDetails pointDetails)
        {
            var deleted = _context.PointsDetails.Remove(pointDetails);
            await _context.SaveChangesAsync();
            return deleted.Entity;
        }
    }
}
