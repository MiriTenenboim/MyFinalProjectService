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
    public class UsersDetailsService : IUsersDetailsService
    {
        private readonly IUsersDetailsRepository _usersDetailsRepository;
        private readonly IMapper _mapper;

        public UsersDetailsService(IUsersDetailsRepository usersDetailsRepository, IMapper mapper)
        {
            _usersDetailsRepository = usersDetailsRepository;
            _mapper = mapper;
        }

        public async Task<UsersDetailsDTO> AddUserAsync(UsersDetailsDTO userDetails)
        {
            var checkExist = GetUserByNamePasswordAsync(userDetails.UserName, userDetails.UserPassword).Result;
            if (checkExist == null)
                return _mapper.Map<UsersDetailsDTO>(await _usersDetailsRepository.AddUserAsync(_mapper.Map<UsersDetails>(userDetails)));
            else
                return null;
        }

        public async Task<UsersDetailsDTO> UpdateUserAsync(UsersDetailsDTO userDetails)
        {
            return _mapper.Map<UsersDetailsDTO>(await _usersDetailsRepository.UpdateUserAsync(_mapper.Map<UsersDetails>(userDetails)));
        }

        public async Task<List<UsersDetailsDTO>> GetAllUsersAsync()
        {
            return _mapper.Map<List<UsersDetailsDTO>>(await _usersDetailsRepository.GetAllUsersAsync());
        }

        public async Task<UsersDetailsDTO> GetUserByIdAsync(int id)
        {
            return _mapper.Map<UsersDetailsDTO>(await _usersDetailsRepository.GetUserByIdAsync(id));
        }

        public async Task<UsersDetailsDTO> GetUserByNamePasswordAsync(string userName, string password)
        {
            return _mapper.Map<UsersDetailsDTO>(await _usersDetailsRepository.GetUserByNamePasswordAsync(userName, password));
        }
    }
}
