using Microsoft.AspNetCore.Mvc;
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

        public IList<Device> Get()
        {
            var d = context.GetAll();
            ;
            return d;
        }


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