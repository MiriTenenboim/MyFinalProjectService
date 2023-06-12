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
    public class CompaniesDetailsService : ICompaniesDetailsService
    {
        private readonly ICompaniesDetailsRepository _companiesDetailsRepository;
        private readonly IMapper _mapper;

        public CompaniesDetailsService(ICompaniesDetailsRepository companiesDetailsRepository, IMapper mapper)
        {
            _companiesDetailsRepository = companiesDetailsRepository;
            _mapper = mapper;
        }

        public async Task<CompaniesDetailsDTO> AddCompanyAsync(CompaniesDetailsDTO companyDetails)
        {
            var checkExist = GetCompanyByNamePasswordAsync(companyDetails.CompanyName, companyDetails.CompanyPassword).Result;
            if (checkExist == null)
            {
                return _mapper.Map<CompaniesDetailsDTO>(await _companiesDetailsRepository.AddCompanyAsync(_mapper.Map<CompaniesDetails>(companyDetails)));
            }
            return null;
        }

        public async Task<CompaniesDetailsDTO> UpdateCompanyAsync(CompaniesDetailsDTO companyDetails)
        {
            return _mapper.Map<CompaniesDetailsDTO>(await _companiesDetailsRepository.UpdateCompanyAsync(_mapper.Map<CompaniesDetails>(companyDetails)));
        }

        public async Task<List<CompaniesDetailsDTO>> GetAllCompaniesAsync()
        {
            return _mapper.Map<List<CompaniesDetailsDTO>>(await _companiesDetailsRepository.GetAllCompaniesAsync());
        }

        public async Task<CompaniesDetailsDTO> GetCompanyByIdAsync(int id)
        {
            return _mapper.Map<CompaniesDetailsDTO>(await _companiesDetailsRepository.GetCompanyByIdAsync(id));
        }

        public async Task<CompaniesDetailsDTO> GetCompanyByNameAsync(string companyName)
        {
            return _mapper.Map<CompaniesDetailsDTO>(await _companiesDetailsRepository.GetCompanyByNameAsync(companyName));
        }

        public async Task<CompaniesDetailsDTO> GetCompanyByNamePasswordAsync(string name, string password)
        {
            return _mapper.Map<CompaniesDetailsDTO>(await _companiesDetailsRepository.GetCompanyByNamePasswordAsync(name, password));
        }
    }
}
