using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories.Interfaces
{
    public interface ISportActivitiesRepository
    {
        // הוספת פעילות ספורט
        Task<SportActivities> AddSportActivityAsync(SportActivities sportActivity);
        // עדכון פעילות ספורט
        Task<SportActivities> UpdateSportActivityAsync(SportActivities sportActivity);
        // שליפת פעילות ספורט לפי קוד
        Task<List<SportActivities>> GetSportActivitiesByIdAsync(int id);
    }
}
