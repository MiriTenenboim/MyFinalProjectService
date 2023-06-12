using SpurringSportActivity.Common.DTO;
using SpurringSportActivity.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpurringSportActivity.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]

    public class UsersDetailsController : ControllerBase
    {
        private readonly IUsersDetailsService _usersDetailsService;

        public UsersDetailsController(IUsersDetailsService usersDetailsService)
        {
            _usersDetailsService = usersDetailsService;
        }

        // GET: api/<UsersDetailsController>        
        [HttpGet]
        public async Task<List<UsersDetailsDTO>> GetAllUsersAsync()
        {
            return await _usersDetailsService.GetAllUsersAsync();
        }

        // GET api/<UsersDetailsController>/5
        [HttpGet("{id}")]
        public async Task<UsersDetailsDTO> GetUserByIdAsync(int id)
        {
            return await _usersDetailsService.GetUserByIdAsync(id);
        }

        // GET api/<UsersDetailsController>/5
        [HttpGet("{userName},{password}")]
        public async Task<UsersDetailsDTO> GetUserByNamePasswordAsync(string userName, string password)
        {
            return await _usersDetailsService.GetUserByNamePasswordAsync(userName, password);
        }

        // POST api/<UsersDetailsController>
        [HttpPost]
        public async Task<UsersDetailsDTO> AddUserAsync([FromBody] UsersDetailsDTO usersDetails)
        {
            return await _usersDetailsService.AddUserAsync(usersDetails);
        }

        // PUT api/<UsersDetailsController>/5
        [HttpPut]
        //[Route("api/UsersDetailsController/UpdateUserAsync/{id}")]
        public async Task<UsersDetailsDTO> UpdateUserAsync([FromBody] UsersDetailsDTO userDetails)
        {
            return await _usersDetailsService.UpdateUserAsync(userDetails);
        }

        // DELETE api/<UsersDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
