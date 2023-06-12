using AutoMapper;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using SpurringSportActivity.Repositories.Repositories;
using SpurringSportActivity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Services
{
    public class CompanyPointsService : ICompanyPointsService
    {
        private readonly ICompanyPointsRepository _companyPointRepository;
        private readonly ICompaniesDetailsRepository _companyDetailsRepository;
        private readonly ICouponDetailsRepository _couponDetailsRepository;
        private readonly IUsersDetailsRepository _usersDetailsRepository;
        private readonly IPublicPointsRepository _publicPointsRepository;
        private readonly IMapper _mapper;

        public CompanyPointsService(ICompanyPointsRepository companyPointRepository, ICompaniesDetailsRepository companyDetailsRepository, ICouponDetailsRepository couponDetailsRepository, IUsersDetailsRepository usersDetailsRepository,IPublicPointsRepository publicPointsRepository, IMapper mapper)
        {
            _companyPointRepository = companyPointRepository;
            _companyDetailsRepository = companyDetailsRepository;
            _couponDetailsRepository = couponDetailsRepository;
            _usersDetailsRepository = usersDetailsRepository;
            _publicPointsRepository = publicPointsRepository;
            _mapper = mapper;
        }

        public async Task<CompanyPointsDTO> AddCompanyPointAsync(CompanyPointsDTO companyPoint)
        {
            //if (companyPoint.Company == null)
            //{
            //    companyPoint.Company = _mapper.Map<CompaniesDetailsDTO>(await _companyDetailsRepository.GetCompanyByIdAsync(companyPoint.CompanyId));
            //    companyPoint.Coupon = _mapper.Map<CouponDetailsDTO>(await _couponDetailsRepository.GetCouponDetailsAsync(companyPoint.CouponId));
            //}
            return _mapper.Map<CompanyPointsDTO>(await _companyPointRepository.AddCompanyPointAsync(_mapper.Map<CompanyPoints>(companyPoint)));
        }

        public async Task<List<CompanyPointsDTO>> GetAllCompaniesPointsAsync()
        {
            return _mapper.Map<List<CompanyPointsDTO>>(await _companyPointRepository.GetAllCompaniesPointsAsync());
        }

        public async Task<List<CompanyPointsDTO>> GetCompanyPointAsync(int companyId)
        {
            return _mapper.Map<List<CompanyPointsDTO>>(await _companyPointRepository.GetCompanyPointAsync(companyId));
        }
    }
}
