using AutoMapper;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using SpurringSportActivity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Services
{
    internal class CouponDetailsService : ICouponDetailsService
    {
        private readonly ICouponDetailsRepository _couponDetailsRepository;
        private readonly IMapper _mapper;

        public CouponDetailsService(ICouponDetailsRepository couponDetailsRepository, IMapper mapper)
        {
            _couponDetailsRepository = couponDetailsRepository;
            _mapper = mapper;
        }

        public async Task<CouponDetailsDTO> AddCouponDetailsAsync(CouponDetailsDTO couponDetails)
        {
            return _mapper.Map<CouponDetailsDTO>(await _couponDetailsRepository.AddCouponDetailsAsync(_mapper.Map<CouponDetails>(couponDetails)));
        }

        public async Task<List<CouponDetailsDTO>> GetAllCouponDetailsAsync()
        {
            return _mapper.Map<List<CouponDetailsDTO>>(await _couponDetailsRepository.GetAllCouponDetailsAsync());
        }

        public async Task<CouponDetailsDTO> GetCouponDetailsAsync(int id)
        {
            return _mapper.Map<CouponDetailsDTO>(await _couponDetailsRepository.GetCouponDetailsAsync(id));
        }
    }
}
