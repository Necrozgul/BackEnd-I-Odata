using Microsoft.AspNetCore.OData.Deltas;
using Models;
using System.Collections.Generic;

namespace Model
{
    public interface IContractRepository
    {
        void Delete(int id);
        Contract Get(int id);
        IList<Contract> GetAll();
        void Post(Contract obj);
        void Put(Contract obj);

        void Patch(int key, Delta<Contract> obj);
    }
}