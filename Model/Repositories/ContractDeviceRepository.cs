using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ContractDeviceRepository : IContractDeviceRepository
    {
        RentalDBContextOLD db;
        public ContractDeviceRepository(RentalDBContextOLD _db)
        {
            this.db = _db;
        }
        public IList<Contract_Device> GetAll()
        {
            return db.Contract_Device_Relations.ToArray();
        }
        public Contract_Device Get(int id)
        {
            return db.Contract_Device_Relations.FirstOrDefault(t => t.Id == id);
        }


        public void Post(Contract_Device obj)
        {
            db.Contract_Device_Relations.Add(obj);
            db.SaveChanges();
        }

        public void Put(Contract_Device obj)
        {
            var old = Get(obj.Id);
            old.ContractId = obj.ContractId;
            old.DeviceId = obj.DeviceId;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Get(id));
            db.SaveChanges();
        }
    }
}
