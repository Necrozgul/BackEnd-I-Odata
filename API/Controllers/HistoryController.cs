using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Model;
using Models;

namespace API.Controllers
{

    public class HistoryController : ODataController
    {

        private readonly ILogger<HistoryController> _logger;
        IHistoryRepository context;

        public HistoryController(ILogger<HistoryController> logger, IHistoryRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        [EnableQuery]
        public IList<History> Get()
        {
            var d = context.GetAll();
            return d;
        }


        public IActionResult Post(History dev)
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