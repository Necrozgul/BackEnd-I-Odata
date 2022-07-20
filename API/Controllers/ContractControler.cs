using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Model;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractControler : ControllerBase
    {

        private readonly ILogger<ContractControler> _logger;
        IContractRepository context;

        public ContractControler(ILogger<ContractControler> logger, IContractRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        [HttpGet]
        //[EnableQuery]
        public IList<Contract> Get()
        {
            var d = context.GetAll();
            ;
            return d;
        }


        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] Contract dev)
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

        [HttpPut]
        [EnableQuery]
        public IActionResult Put([FromBody] Contract dev)
        {
            try
            {
                context.Put(dev);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [EnableQuery]
        public IActionResult Delete(int id)
        {
            try
            {
                context.Delete(id);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}