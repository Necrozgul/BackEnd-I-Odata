using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Model;
using Models;

namespace API.Controllers
{

    public class DeviceController : ODataController
    {

        private readonly ILogger<DeviceController> _logger;
        IDeviceRepository context;

        public DeviceController(ILogger<DeviceController> logger, IDeviceRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        [EnableQuery()]
        [HttpGet]
        public IList<Device> Get()
        {
            var d = context.GetAll();
            ;
            return d;
        }
        [HttpPost]
        public IActionResult Post(Device device)
        {
            try
            {
                context.Post(device);
                return Ok("Siker");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPatch]
        public IActionResult Patch([FromODataUri] int key, Delta<Device> device)
        {
            ;
            try
            {
                context.Patch(key,device);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromODataUri] int key)
        {
            try
            {
                context.Delete(key);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }
    }
}