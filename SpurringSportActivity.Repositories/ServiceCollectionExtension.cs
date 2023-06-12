using SpurringSportActivity.Repositories.Interfaces;
using SpurringSportActivity.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Repositories
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompaniesDetailsRepository, CompaniesDetailsRepository>();
            services.AddScoped<ICompanyPointsRepository, CompanyPointsRepository>();
            services.AddScoped<ICouponDetailsRepository, CouponDetailsRepository>();
            services.AddScoped<IPointDetailsRepository, PointDetailsRepository>();
            services.AddScoped<IPublicPointsRepository, PublicPointsRepository>();
            services.AddScoped<ISportActivitiesRepository, SportActivitiesRepository>();
            services.AddScoped<IUserPointsRepository, UserPointsRepository>();
            services.AddScoped<IUsersDetailsRepository, UsersDetailsRepository>();

            return services;
        }
    }
}
