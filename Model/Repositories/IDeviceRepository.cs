using Microsoft.AspNetCore.OData.Deltas;
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
        void Put(int key,Device obj);

        void Patch(int key, Delta<Device> obj);
    }
}