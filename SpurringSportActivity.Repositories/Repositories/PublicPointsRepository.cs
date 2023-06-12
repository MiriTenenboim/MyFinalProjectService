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
    public class PublicPointsRepository : IPublicPointsRepository
    {
        private readonly IContext _context;

        public PublicPointsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<PublicPoints> AddPublicPointAsync(PublicPoints publicPoint)
        {
            var added = await _context.PublicPoints.AddAsync(publicPoint);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<List<PublicPoints>> GetAllNotRealizedPoints(Area area)
        {
            // בדיקה נוספת - אם הנקודה בתוך האזור שהמשתמש בחר
            return await _context.PublicPoints
                .Include(point => point.Point)
                .ThenInclude(point => point.UserPoint)
                .Include(point => point.Point.CompanyPoint)
                .ThenInclude(point => point.Coupon)
                .Where(point =>
                (point.Point.IsRealized == false) &&
                (point.Point.PointX >= area.vertex1X) &&
                (point.Point.PointX <= area.vertex2X) &&
                (point.Point.PointY >= area.vertex1Y) &&
                (point.Point.PointY <= area.vertex2Y))
                .ToListAsync();
        }

        public async Task<List<PublicPoints>> GetAllPublicPoints()
        {
            return await _context.PublicPoints.Include(publicPoint => publicPoint.Point)
                .Include(point => point.Point)
                .ThenInclude(point => point.UserPoint)
                .Include(point => point.Point.CompanyPoint)
                .ThenInclude(point => point.Coupon)
                .ToListAsync();
        }
    }
}
