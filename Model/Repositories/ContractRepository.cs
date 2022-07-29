using Microsoft.AspNetCore.OData.Deltas;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContractRepository : IContractRepository
    {
        RentalDBContext db;
        public ContractRepository(RentalDBContext _db)
        {
            this.db = _db;
        }
        public IList<Contract> GetAll()
        {
            return db.Contracts.ToArray();
        }
        public Contract Get(int id)
        {
            return db.Contracts.FirstOrDefault(t => t.Id == id);
        }

        public void Post(Contract obj)
        {
            db.Contracts.Add(obj);
            db.SaveChanges();
        }
        public void Put(int key, Contract obj)
        {
            var entity = db.Contracts.Find(key);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            db.SaveChangesAsync();
        }


        public void Patch(int key, Delta<Contract> obj)
        {
            var entity = db.Contracts.Find(key);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            obj.Patch(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Get(id));
            db.SaveChanges();
        }

    }
}
