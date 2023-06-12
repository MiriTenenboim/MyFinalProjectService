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
    public class CouponDetailsController : ControllerBase
    {
        private readonly ICouponDetailsService _couponDetailsService;

        public CouponDetailsController(ICouponDetailsService couponDetailsService)
        {
            _couponDetailsService = couponDetailsService;
        }

        // GET: api/<CouponDetailsController>
        [HttpGet]
        public async Task<List<CouponDetailsDTO>> GetAllCouponDetailsAsync()
        {
            return await _couponDetailsService.GetAllCouponDetailsAsync();
        }

        // GET api/<CouponDetailsController>/5
        [HttpGet("{id}")]
        public async Task<CouponDetailsDTO> GetCouponDetailsAsync(int id)
        {
            return await _couponDetailsService.GetCouponDetailsAsync(id);
        }

        // POST api/<CouponDetailsController>
        [HttpPost]
        public async Task<CouponDetailsDTO> AddCouponDetailsAsync([FromBody] CouponDetailsDTO couponDetails)
        {
            return await _couponDetailsService.AddCouponDetailsAsync(couponDetails);
        }

        // PUT api/<CouponDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CouponDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
