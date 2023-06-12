using AutoMapper;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Repositories.Interfaces;
using SpurringSportActivity.Repositories.Repositories;
using SpurringSportActivity.Service;
using SpurringSportActivity.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpurringSportActivity.Services.Services
{
    public class UserPointsService : IUserPointsService
    {
        private readonly IUserPointsRepository _userPointRepository;
        private readonly IUsersDetailsRepository _userDetailsRepository;
        private readonly IMapper _mapper;

        public UserPointsService(IUserPointsRepository userPointRepository, IUsersDetailsRepository userDetailsRepository, IMapper mapper)
        {
            _userPointRepository = userPointRepository;
            _userDetailsRepository = userDetailsRepository;
            _mapper = mapper;
        }

        public async Task<UserPointsDTO> AddUserPointAsync(UserPointsDTO userPoint)
        {
            if (userPoint.User == null)
            {
                userPoint.User = _mapper.Map<UsersDetailsDTO>(await _userDetailsRepository.GetUserByIdAsync(userPoint.UserId));
            }            
            return _mapper.Map<UserPointsDTO>(await _userPointRepository.AddUserPointAsync(_mapper.Map<UserPoints>(userPoint)));
        }

        public async Task<List<UserPointsDTO>> GetUserPointsAsync(int id)
        {
            return _mapper.Map<List<UserPointsDTO>>(await _userPointRepository.GetUserPointsAsync(id));
        }

        public async Task<UserPointsDTO> GetUserPointByDueDateAsync(int id,DateTime dueDate)
        {
            return _mapper.Map<UserPointsDTO>(await _userPointRepository.GetUserPointByDueDateAsync(id,dueDate));
        }
    }
}
