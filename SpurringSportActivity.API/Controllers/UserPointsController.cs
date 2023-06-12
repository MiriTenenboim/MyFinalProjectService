using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Services.Interfaces;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpurringSportActivity.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]

    public class UserPointsController : ControllerBase
    {
        private readonly IUserPointsService _userPointsService;

        public UserPointsController(IUserPointsService userPointsService)
        {
            _userPointsService = userPointsService;
        }

        // GET api/<UserPointsController>/5
        [HttpGet("{id}")]
        public async Task<List<UserPointsDTO>> GetUserPointsAsync(int id)
        {
            return await _userPointsService.GetUserPointsAsync(id);
        }

        //[HttpGet("{id}")]
        //public async Task<UserPointsDTO> GetUserPointByDueDateAsync(int id)
        //{
        //    var dueDate = DateTime.Now;
        //    return await _userPointsService.GetUserPointByDueDateAsync(id,dueDate);
        //}

        // POST api/<UserPointsController>
        [HttpPost]
        public async Task<UserPointsDTO> AddUserPointAsync([FromBody] UserPointsDTO userPoint)
        {
            return await _userPointsService.AddUserPointAsync(userPoint);
        }

        // PUT api/<UserPointsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserPointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
