using AutoMapper;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using SpurringSportActivity.Service;
using SpurringSportActivity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Services
{   
    public class PublicPointsService : IPublicPointService
    {

        private readonly IPublicPointsRepository _publicPointsRepository;
        private readonly IMapper _mapper;

        public PublicPointsService(IPublicPointsRepository publicPointsRepository, IMapper mapper)
        {
            _publicPointsRepository = publicPointsRepository;
            _mapper = mapper;
        }

        public async Task<PublicPointDTO> AddPublicPointAsync(PublicPointDTO publicPoint)
        {
            return _mapper.Map<PublicPointDTO>(await _publicPointsRepository.AddPublicPointAsync(_mapper.Map<PublicPoints>(publicPoint)));
        }

        public async Task<List<PublicPointDTO>> GetAllNotRealizedPoints(Area area)
        {
            return _mapper.Map<List<PublicPointDTO>>(await _publicPointsRepository.GetAllNotRealizedPoints(area));
        }

        public async Task<List<PublicPointDTO>> GetAllPublicPoints()
        {
            return _mapper.Map<List<PublicPointDTO>>(await _publicPointsRepository.GetAllPublicPoints());
        }
    }
}
