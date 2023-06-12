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
    public class CompanyPointsRepository : ICompanyPointsRepository
    {
        private readonly IContext _context;

        public CompanyPointsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<CompanyPoints> AddCompanyPointAsync(CompanyPoints companyPoint)
        {
            if (companyPoint.Company != null)
            {
                _context.CompaniesDetails.Attach(companyPoint.Company);
                _context.CouponDetails.Attach(companyPoint.Coupon);
            }
            var added = await _context.CompanyPoints.AddAsync(companyPoint);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<List<CompanyPoints>> GetAllCompaniesPointsAsync()
        {
            return await _context.CompanyPoints
                .Include(companyPoint => companyPoint.Company)
                .Include(companyPoint => companyPoint.Coupon)
                .ToListAsync();
        }

        public async Task<List<CompanyPoints>> GetCompanyPointAsync(int companyId)
        {
            return await _context.CompanyPoints
                .Include(companyPoint => companyPoint.Company)
                .Include(companyPoint => companyPoint.Coupon)
                .Where(company => company.Company.CompanyId == companyId).ToListAsync();
        }
    }
}
