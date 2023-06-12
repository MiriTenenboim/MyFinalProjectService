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
    public class SportsActivitiesController : ControllerBase
    {
        private readonly ISportActivitiesService _sportActivityService;

        public SportsActivitiesController(ISportActivitiesService sportActivityService)
        {
            _sportActivityService = sportActivityService;
        }

        // GET: api/<SportsActivitiesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SportsActivitiesController>/5
        [HttpGet("{id}")]
        public async Task<List<SportActivitiesDTO>> GetSportActivitiesByIdAsync(int id)
        {
            return await _sportActivityService.GetSportActivitiesByIdAsync(id);
        }

        // POST api/<SportsActivitiesController>
        [HttpPost]
        public async Task<SportActivitiesDTO> AddSportActivityAsync([FromBody] SportActivitiesDTO sportActivity)
        {
            sportActivity.StartDate = DateTime.Now;
            sportActivity.CompletionDate = DateTime.Now;
            return await _sportActivityService.AddSportActivityAsync(sportActivity);
        }

        // PUT api/<SportsActivitiesController>/5
        [HttpPut]
        public async Task<SportActivitiesDTO> UpdateSportActivityAsync([FromBody] SportActivitiesDTO sportActivity)
        {
            sportActivity.CompletionDate = DateTime.Now;
            return await _sportActivityService.UpdateSportActivityAsync(sportActivity);
        }

        // DELETE api/<SportsActivitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
