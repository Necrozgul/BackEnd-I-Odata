using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
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

        [EnableQuery]
        public IList<Contract> Get()
        {
            var d = context.GetAll();
            ;
            return d;
        }

        public IActionResult Post(Contract cont)
        {
            try
            {
                context.Post(cont);
                return Ok("Siker");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IActionResult Patch([FromODataUri] int key, Delta<Contract> contract)
        {
            ;
            try
            {
                context.Patch(key, contract);
                return Ok("Siker");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        //Delete Method
        public IActionResult Delete(int key)
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