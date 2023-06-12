using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpurringSportActivity.Repositories;
using SpurringSportActivity.Service;
using SpurringSportActivity.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpurringSportActivity.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class BestRouteController : ControllerBase
    {
        private readonly IBestRoute _bestRoute;

        public BestRouteController(IBestRoute bestRoute)
        {
            _bestRoute = bestRoute;
        }

        // GET: api/<BestRouteController>/5
        [HttpGet/*("{area}")*/]
        public List<Node> GetTheBestRoute(/*int id, double latitude, double longitude, Area area*/)
        {
            int id = 2;
            double latitude = 32.851061;
            double longitude = 34.958488;
            Area area = new Area(30.046951, 39.054189, 30.954519, 39.962758);
            return _bestRoute.GetTheBestRoute(id, latitude, longitude, area);
        }
    }
}
