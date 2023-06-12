using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Repositories
{
    public class CompaniesDetailsRepository : ICompaniesDetailsRepository
    {
        private readonly IContext _context;

        public CompaniesDetailsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<CompaniesDetails> AddCompanyAsync(CompaniesDetails companyDetails)
        {
            var added = await _context.CompaniesDetails.AddAsync(companyDetails);
            await _context.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<CompaniesDetails> UpdateCompanyAsync(CompaniesDetails companyDetails)
        {
            var updatedCompany = _context.CompaniesDetails.Update(companyDetails);
            await _context.SaveChangesAsync();
            return updatedCompany.Entity;
        }

        public async Task<CompaniesDetails> GetCompanyByNameAsync(string companyName)
        {
            return await _context.CompaniesDetails.FirstAsync(companyDetails => companyDetails.CompanyName == companyName);
        }

        public async Task<CompaniesDetails> GetCompanyByPasswordAsync(string companyPassword)
        {
            return await _context.CompaniesDetails.FirstAsync(companyDetails => companyDetails.CompanyPassword == companyPassword);
        }

        public async Task<List<CompaniesDetails>> GetAllCompaniesAsync()
        {
            return await _context.CompaniesDetails.ToListAsync();
        }

        public async Task<CompaniesDetails> GetCompanyByIdAsync(int id)
        {
            return await _context.CompaniesDetails.FindAsync(id);
        }

        public async Task<CompaniesDetails> GetCompanyByNamePasswordAsync(string name, string password)
        {
            var company = await _context.CompaniesDetails.FirstOrDefaultAsync(company => (company.CompanyName == name) && (company.CompanyPassword == password));
            return (company != null) ? company : null;
        }
    }
}
