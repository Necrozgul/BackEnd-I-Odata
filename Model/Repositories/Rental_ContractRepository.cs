using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repositories
{
    public class Rental_ContractRepository
    {
        RentalDBContext db;
        public Rental_ContractRepository(RentalDBContext _db)
        {
            this.db = _db;
        }
        public IList<Contract_Device_Relation> GetAll()
        {
            return db.Contract_Device_Relations.ToArray();
        }
        public Contract_Device_Relation Get(int id)
        {
            return db.Contract_Device_Relations.FirstOrDefault(t => t.Id == id);
        }


        public void Post(Contract_Device_Relation obj)
        {
            db.Contract_Device_Relations.Add(obj);
            db.SaveChanges();
        }

        public void Put(Contract_Device_Relation obj)
        {
            var old = Get(obj.Id);
            old = obj;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Get(id));
            db.SaveChanges();
        }
    }
}
