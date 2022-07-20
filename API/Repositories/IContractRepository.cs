﻿using System.Collections.Generic;

namespace API
{
    public interface IContractRepository
    {
        void Delete(int id);
        Contract Get(int id);
        IList<Contract> GetAll();
        void Post(Contract obj);
        void Put(Contract obj);
    }
}