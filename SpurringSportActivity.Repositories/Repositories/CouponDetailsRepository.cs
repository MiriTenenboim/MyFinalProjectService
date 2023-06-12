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
    public class CouponDetailsRepository : ICouponDetailsRepository
    {
        private readonly IContext _context;

        public CouponDetailsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<CouponDetails> AddCouponDetailsAsync(CouponDetails couponDetails)
        {
            var added = await _context.CouponDetails.AddAsync(couponDetails);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<List<CouponDetails>> GetAllCouponDetailsAsync()
        {
            return await _context.CouponDetails.ToListAsync();
        }

        public async Task<CouponDetails> GetCouponDetailsAsync(int id)
        {
            return await _context.CouponDetails.FindAsync(id);
        }
    }
}
