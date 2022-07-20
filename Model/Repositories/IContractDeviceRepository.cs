﻿using Models;
using System.Collections.Generic;

namespace Models
{
    public interface IContractDeviceRepository
    {
        void Delete(int id);
        Contract_Device Get(int id);
        IList<Contract_Device> GetAll();
        void Post(Contract_Device obj);
        void Put(Contract_Device obj);
    }
}