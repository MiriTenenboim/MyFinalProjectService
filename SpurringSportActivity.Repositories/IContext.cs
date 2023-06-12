using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using SpurringSportActivity.Repositories.Entities;

namespace SpurringSportActivity.Repositories
{
    public interface IContext
    {
        DbSet<CompaniesDetails> CompaniesDetails { get; set; }
        DbSet<CompanyPoints> CompanyPoints { get; set; }
        DbSet<CouponDetails> CouponDetails { get; set; }
        DbSet<PointsDetails> PointsDetails { get; set; }
        DbSet<PublicPoints> PublicPoints { get; set; }
        DbSet<SportActivities> SportsActivities { get; set; }
        DbSet<UserPoints> UserPoints { get; set; }
        DbSet<UsersDetails> UsersDetails { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
