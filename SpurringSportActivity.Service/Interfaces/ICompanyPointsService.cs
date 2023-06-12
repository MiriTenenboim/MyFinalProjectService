using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Interfaces
{
    public interface ICompanyPointsService
    {
        // הוספת נקודה לחברה
        Task<CompanyPointsDTO> AddCompanyPointAsync(CompanyPointsDTO companyPoints);
        // שליפת כל הנקודות לכל החברות
        Task<List<CompanyPointsDTO>> GetAllCompaniesPointsAsync();
        // שליפת כל הנקודות לחברה מסוימת
        Task<List<CompanyPointsDTO>> GetCompanyPointAsync(int companyId);
    }
}
