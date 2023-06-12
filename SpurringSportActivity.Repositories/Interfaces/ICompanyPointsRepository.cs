using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Interfaces
{
    public interface ICompanyPointsRepository
    {
        // הוספת נקודה לחברה
        Task<CompanyPoints> AddCompanyPointAsync(CompanyPoints companyPoints);
        // שליפת כל הנקודות לכל החברות
        Task<List<CompanyPoints>> GetAllCompaniesPointsAsync();
        // שליפת כל הנקודות לחברה מסוימת
        Task<List<CompanyPoints>> GetCompanyPointAsync(int companyId);
    }
}
