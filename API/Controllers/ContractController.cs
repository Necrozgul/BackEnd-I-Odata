using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Model;
using Models;

namespace API.Controllers
{
    public class ContractController : ODataController
    {

        private readonly ILogger<ContractController> _logger;
        IContractRepository context;

        public ContractController(ILogger<ContractController> logger, IContractRepository repo)
        {
            _logger = logger;
            context = repo;
        }

        public IList<Contract> Get()
        {
            var d = context.GetAll();
            ;
            return d;
        }

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