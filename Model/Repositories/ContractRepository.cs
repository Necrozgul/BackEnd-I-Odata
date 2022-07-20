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

        public void Put(Contract obj)
        {
            if (obj != null)
            {
                var old = Get(obj.Id);
                old.Name = obj.Name;
                old.Startdate = obj.Startdate;
                old.Enddate = obj.Enddate;
                old.Email = obj.Email;
                old.Phone = obj.Phone;
                old.Address = obj.Address;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("[Error] : You didnt gave the contract so cant edit");
            }
            
        }

        public void Delete(int id)
        {
            db.Remove(Get(id));
            db.SaveChanges();
        }

    }
}
