using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Model;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {

        private readonly ILogger<HistoryController> _logger;
        IHistoryRepository context;

        public HistoryController(ILogger<HistoryController> logger, IHistoryRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        [HttpGet]
        //[EnableQuery]
        public IList<History> Get()
        {
            var d = context.GetAll();
            return d;
        }


        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] History dev)
        {
            try
            {
                context.Post(dev);
                return Ok("Siker");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
    }
}