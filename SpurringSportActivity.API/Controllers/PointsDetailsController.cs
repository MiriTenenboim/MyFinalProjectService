using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Repositories.Entities;
using SpurringSportActivity.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpurringSportActivity.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class PointsDetailsController : ControllerBase
    {
        private readonly IPointDetailsService _pointDetailsService;

        public PointsDetailsController(IPointDetailsService pointDetailsService)
        {
            _pointDetailsService = pointDetailsService;
        }

        // GET: api/<PointsDetailsController>
        [HttpGet]
        public async Task<List<PointDetailsDTO>> GetAllPointsAsync()
        {
            return await _pointDetailsService.GetAllPointsAsync();
        }

        // GET api/<PointsDetailsController>/5
        [HttpGet("{userOrCompany},{id}")]
        public async Task<List<PointDetailsDTO>> GetPointsByIdAsync(int userOrCompany, int id)
        {
            return await _pointDetailsService.GetPointsByIdAsync(userOrCompany, id);
        }

        [HttpGet("{id}")]
        public async Task<List<PointDetailsDTO>> GetRealizedPointsAsync(int id)
        {
            return await _pointDetailsService.GetRealizedPointsAsync(id);
        }

        // POST api/<PointsDetailsController>
        [HttpPost]
        public async Task<PointDetailsDTO> AddPointDetailsAsync([FromBody] PointDetailsDTO pointDetails)
        {
               return await _pointDetailsService.AddPointDetailsAsync(pointDetails);
        }


        // PUT api/<PointsDetailsController>/5
        [HttpPut("{id},{userId}")]
        public async Task<PointDetailsDTO> UpdateRealizedPointAsync(int id, int userId)
        {
            return await _pointDetailsService.UpdateRealizedPointAsync(id, userId);
        }

        [HttpPut]
        public async Task<PointDetailsDTO> UpdatePointAsync(PointDetailsDTO pointDetails)
        {
            return await _pointDetailsService.UpdatePointAsync(pointDetails);
        }

        // DELETE api/<PointsDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<PointDetailsDTO> DeletePointAsync(PointDetailsDTO pointDetails)
        {
            return await _pointDetailsService.DeletePointAsync(pointDetails);
        }
    }
}
