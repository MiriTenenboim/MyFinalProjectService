using Microsoft.Extensions.DependencyInjection;
using SpurringSportActivity.Services.Interfaces;
using SpurringSportActivity.Repositories;
using SpurringSportActivity.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpurringSportActivity.Services;
using SpurringSportActivity.Service.Interfaces;

namespace SpurringSportActivity.Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();

            services.AddScoped<ICompaniesDetailsService, CompaniesDetailsService>();
            services.AddScoped<ICompanyPointsService, CompanyPointsService>();
            services.AddScoped<ICouponDetailsService, CouponDetailsService>();
            services.AddScoped<IPointDetailsService, PointDetailsService>();
            services.AddScoped<IPublicPointService, PublicPointsService>();
            services.AddScoped<ISportActivitiesService, SportActivitiesService>();
            services.AddScoped<IUserPointsService, UserPointsService>();
            services.AddScoped<IUsersDetailsService, UsersDetailsService>();
            services.AddScoped<IBestRoute, BestRoute>();
            services.AddScoped<IFindNodes,FindNodes>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
