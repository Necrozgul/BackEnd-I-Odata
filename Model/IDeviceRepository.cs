using Models;
using System.Collections.Generic;

namespace Model
{
    public interface IDeviceRepository
    {
        void Delete(int id);
        Device Get(int id);
        IList<Device> GetAll();
        void Post(Device obj);
        void Put(Device obj);
    }
}