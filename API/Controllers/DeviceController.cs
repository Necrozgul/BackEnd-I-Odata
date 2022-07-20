using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {

        private readonly ILogger<DeviceController> _logger;
        IDeviceRepository context;

        public DeviceController(ILogger<DeviceController> logger, IDeviceRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        [HttpGet]
        //[EnableQuery]
        public IList<Device> Get()
        {
            var d = context.GetAll();
            ;
            return d;
        }


        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post([FromBody] Device dev)
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
        public IActionResult Put([FromBody] Device dev)
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