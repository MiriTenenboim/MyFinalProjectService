using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Interfaces
{
    public interface ICompaniesDetailsRepository
    {
        // שליפת פרטי כל החברות
        Task<List<CompaniesDetails>> GetAllCompaniesAsync();
        // שליפת פרטי חברה לפי קוד
        Task<CompaniesDetails> GetCompanyByIdAsync(int id);
        // הוספת חברה
        Task<CompaniesDetails> AddCompanyAsync(CompaniesDetails companyDetails);
        // עדכון חברה
        Task<CompaniesDetails> UpdateCompanyAsync(CompaniesDetails companyDetails);
        // שליפת חברה לפי שם
        Task<CompaniesDetails> GetCompanyByNameAsync(string companyName);
        // שליפת חברה לפי שם וסיסמא
        Task<CompaniesDetails> GetCompanyByNamePasswordAsync(string name, string password);
    }
}
