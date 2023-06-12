using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SpurringSportActivity.Service;
using SpurringSportActivity.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpurringSportActivity.API.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class FindNodesController : ControllerBase
    {

        private readonly IFindNodes _findNodes;

        public FindNodesController(IFindNodes findNodes)
        {
            _findNodes = findNodes;
        }

        // GET: api/<FindNodesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET api/<FindNodesController>/5
        [HttpGet("{id},{x},{y}")]
        public QuadTree GetClosestNodes(int id, double x, double y)
        {
            return _findNodes.OnLoad(id, x, y);
        }

        // POST api/<FindNodesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FindNodesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FindNodesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
