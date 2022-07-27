using Models;
using System.Collections.Generic;

namespace Models
{
    public interface IContractDeviceRepository
    {
        void Delete(int id);
        ContractDevice Get(int id);
        IList<ContractDevice> GetAll();
        void Post(ContractDevice obj);
        void Put(ContractDevice obj);
    }
}