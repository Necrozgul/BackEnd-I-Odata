using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Models;

namespace API.Controllers
{

    public class ContractDeviceController : ODataController
    {

        private readonly ILogger<ContractDevice> _logger;
        IContractDeviceRepository context;

        public ContractDeviceController(ILogger<ContractDevice> logger, IContractDeviceRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        

        public IList<ContractDevice> Get()
        {
            var d = context.GetAll();
            return d;
        }


        public IActionResult Post(ContractDevice dev)
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

        public IActionResult Patch([FromODataUri] ContractDevice dev)
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
