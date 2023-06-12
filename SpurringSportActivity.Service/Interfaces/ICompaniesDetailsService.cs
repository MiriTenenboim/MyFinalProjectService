using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Interfaces
{
    public interface ICompaniesDetailsService
    {
        // שליפת פרטי כל החברות
        Task<List<CompaniesDetailsDTO>> GetAllCompaniesAsync();
        // שליפת פרטי חברה לפי קוד
        Task<CompaniesDetailsDTO> GetCompanyByIdAsync(int id);
        // הוספת חברה
        Task<CompaniesDetailsDTO> AddCompanyAsync(CompaniesDetailsDTO companyDetails);
        // עדכון חברה
        Task<CompaniesDetailsDTO> UpdateCompanyAsync(CompaniesDetailsDTO companyDetails);
        // שליפת חברה לפי שם
        Task<CompaniesDetailsDTO> GetCompanyByNameAsync(string companyName);
        // שליפת חברה לפי שם וסיסמא
        Task<CompaniesDetailsDTO> GetCompanyByNamePasswordAsync(string name,string password);

    }
}
