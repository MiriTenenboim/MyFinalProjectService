using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Interfaces
{
    public interface ISportActivitiesService
    {
        // הוספת פעילות ספורט
        Task<SportActivitiesDTO> AddSportActivityAsync(SportActivitiesDTO sportActivity);
        // עדכון פעילות ספורט
        Task<SportActivitiesDTO> UpdateSportActivityAsync(SportActivitiesDTO sportActivity);
        // שליפת פעילות ספורט לפי קוד
        Task<List<SportActivitiesDTO>> GetSportActivitiesByIdAsync(int id);
    }
}
