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
    public class PublicPointsController : ControllerBase
    {
        private readonly IPublicPointService _publicPointService;

        public PublicPointsController(IPublicPointService publicPointService)
        {
            _publicPointService = publicPointService;
        }

        // GET: api/<PublicPointsController>
        [HttpGet]
        public async Task<List<PublicPointDTO>> GetAllPublicPoints()
        {
            return await _publicPointService.GetAllPublicPoints();
        }

        // GET api/<PublicPointsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PublicPointsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublicPointsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublicPointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
