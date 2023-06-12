using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpurringSportActivity.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]

    public class CompaniesDetailsController : ControllerBase
    {
        private readonly ICompaniesDetailsService _companiesDetailsService;

        public CompaniesDetailsController(ICompaniesDetailsService companiesDetailsService)
        {
            _companiesDetailsService = companiesDetailsService;
        }

        // GET: api/<CompaniesDetailsController>
        [HttpGet]
        public async Task<List<CompaniesDetailsDTO>> GetAllCompaniesAsync()
        {
            return await _companiesDetailsService.GetAllCompaniesAsync();
        }

        // GET api/<CompaniesDetailsController>/5
        [HttpGet("{id}")]
        public async Task<CompaniesDetailsDTO> GetCompanyByIdAsync(int id)
        {
            return await _companiesDetailsService.GetCompanyByIdAsync(id);
        }

        // GET api/<CompaniesDetailsController>/5
        [HttpGet("{name},{password}")]
        public async Task<CompaniesDetailsDTO> GetCompanyByNamePasswordAsync(string name, string password)
        {
            return await _companiesDetailsService.GetCompanyByNamePasswordAsync(name,password);
        }

        // POST api/<CompaniesDetailsController>
        [HttpPost]
        public async Task<CompaniesDetailsDTO> AddCompanyAsync([FromBody] CompaniesDetailsDTO companyDetails)
        {
            return await _companiesDetailsService.AddCompanyAsync(companyDetails);
        }

        // PUT api/<CompaniesDetailsController>/5
        [HttpPut]
        public async Task<CompaniesDetailsDTO> UpdateCompanyAsync([FromBody] CompaniesDetailsDTO companyDetails)
        {
            return await _companiesDetailsService.UpdateCompanyAsync(companyDetails);
        }

        // DELETE api/<CompaniesDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
