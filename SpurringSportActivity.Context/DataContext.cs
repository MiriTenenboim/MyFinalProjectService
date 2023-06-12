using SpurringSportActivity.Repositories;
using SpurringSportActivity.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<UsersDetails> UsersDetails { get; set; }
        public DbSet<CompaniesDetails> CompaniesDetails { get; set; }
        public DbSet<CompanyPoints> CompanyPoints { get; set; }
        public DbSet<CouponDetails> CouponDetails { get; set; }
        public DbSet<PointsDetails> PointsDetails { get; set; }
        public DbSet<PublicPoints> PublicPoints { get; set; }
        public DbSet<SportActivities> SportsActivities { get; set; }
        public DbSet<UserPoints> UserPoints { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CompanyPoints>()
        //        .Property(p => p.Coupon)
        //        .HasDefaultValue("NULL");
        //}
    }
}
