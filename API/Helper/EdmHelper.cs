using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Models;

namespace API.Helper
{
    public class EdmHelper
    {
        public static IEdmModel GetEdmModel()
        {
            var edmBuilder = new ODataConventionModelBuilder();
            edmBuilder.EntitySet<Device>("Device");
            edmBuilder.EntitySet<History>("History");
            edmBuilder.EntitySet<Contract>("Contract");
            edmBuilder.EntitySet<ContractDevice>("ContractDevice");
            return edmBuilder.GetEdmModel();
        }

    }
}
