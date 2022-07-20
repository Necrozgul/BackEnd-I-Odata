using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DeviceRepository : IDeviceRepository
    {
        RentalDBContext db;
        public DeviceRepository(RentalDBContext _db)
        {
            this.db = _db;
        }
        public IList<Device> GetAll()
        {
            return db.Devices.ToArray();
        }
        public Device Get(int id)
        {
            return db.Devices.FirstOrDefault(t => t.DeviceKey == id);
        }


        public void Post(Device obj)
        {
            db.Devices.Add(obj);
            db.SaveChanges();
        }

        public void Put(Device obj)
        {
            var old = Get(obj.DeviceKey);
            old.Name = obj.Name;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Get(id));
            db.SaveChanges();
        }



    }
}
