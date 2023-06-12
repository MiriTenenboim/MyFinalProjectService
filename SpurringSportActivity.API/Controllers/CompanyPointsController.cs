using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpurringSportActivity.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]

    public class CompanyPointsController : ControllerBase
    {
        private readonly ICompanyPointsService _companyPointService;

        public CompanyPointsController(ICompanyPointsService companyPointService)
        {
            _companyPointService = companyPointService;
        }

        // GET: api/<CompanyPointsController>
        [HttpGet]
        public async Task<List<CompanyPointsDTO>> GetAllCompaniesPointsAsync()
        {
            return await _companyPointService.GetAllCompaniesPointsAsync();
        }

        // GET api/<CompanyPointsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyPointsController>
        [HttpPost]
        public async Task<CompanyPointsDTO> AddCompanyPointAsync([FromBody] CompanyPointsDTO companyPoint)
        {
            return await _companyPointService.AddCompanyPointAsync(companyPoint);
        }

        // PUT api/<CompanyPointsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyPointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
