using AutoMapper;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories;
using SpurringSportActivity.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompaniesDetailsDTO, CompaniesDetails>().ReverseMap();
            CreateMap<CompanyPointsDTO, CompanyPoints>().ReverseMap();
            CreateMap<CouponDetailsDTO, CouponDetails>().ReverseMap();
            CreateMap<PointDetailsDTO, PointsDetails>().ReverseMap();
            CreateMap<PublicPointDTO, PublicPoints>().ReverseMap();
            CreateMap<SportActivitiesDTO, SportActivities>().ReverseMap();
            CreateMap<UserPointsDTO, UserPoints>().ReverseMap();
            CreateMap<UsersDetailsDTO, UsersDetails>().ReverseMap();
        }
    }
}
