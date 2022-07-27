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
        RentalDBContext db;
        public ContractDeviceRepository(RentalDBContext _db)
        {
            this.db = _db;
        }
        public IList<ContractDevice> GetAll()
        {
            return db.Contract_Device_Relations.ToArray();
        }
        public ContractDevice Get(int id)
        {
            return db.Contract_Device_Relations.FirstOrDefault(t => t.Id == id);
        }


        public void Post(ContractDevice obj)
        {
            db.Contract_Device_Relations.Add(obj);
            db.SaveChanges();
        }

        public void Put(ContractDevice obj)
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
