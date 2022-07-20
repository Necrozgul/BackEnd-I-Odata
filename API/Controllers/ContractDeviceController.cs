using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractDeviceController : ControllerBase
    {

        private readonly ILogger<Contract_Device> _logger;
        IContractDeviceRepository context;

        public ContractDeviceController(ILogger<Contract_Device> logger, IContractDeviceRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        [HttpGet]
        //[EnableQuery]
        public IList<Contract_Device> Get()
        {
            var d = context.GetAll();
            return d;
        }


        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] Contract_Device dev)
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
        public IActionResult Put([FromBody] Contract_Device dev)
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
