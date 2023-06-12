using AutoMapper;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using SpurringSportActivity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Services
{
    public class SportActivitiesService : ISportActivitiesService
    {
        private readonly ISportActivitiesRepository _sportActivitiesRepository;
        private readonly IMapper _mapper;

        public SportActivitiesService(ISportActivitiesRepository sportActivitiesRepository, IMapper mapper)
        {
            _sportActivitiesRepository = sportActivitiesRepository;
            _mapper = mapper;
        }

        public async Task<SportActivitiesDTO> AddSportActivityAsync(SportActivitiesDTO sportActivity)
        {
            return _mapper.Map<SportActivitiesDTO>(await _sportActivitiesRepository.AddSportActivityAsync(_mapper.Map<SportActivities>(sportActivity)));
        }

        public async Task<List<SportActivitiesDTO>> GetSportActivitiesByIdAsync(int id)
        {
            return _mapper.Map<List<SportActivitiesDTO>>(await _sportActivitiesRepository.GetSportActivitiesByIdAsync(id));
        }

        public async Task<SportActivitiesDTO> UpdateSportActivityAsync(SportActivitiesDTO sportActivity)
        {
            return _mapper.Map<SportActivitiesDTO>(await _sportActivitiesRepository.UpdateSportActivityAsync(_mapper.Map<SportActivities>(sportActivity)));
        }
    }
}
