using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ContractDeviceRepository : IContractDeviceRepository
    {
        public IList<Contract_Device> GetAll()
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            {
                var devices = session
                    .CreateCriteria(typeof(Contract_Device))
                    .List<Contract_Device>();
                return devices;
            }
        }
        public Contract_Device Get(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
                return session.Get<Contract_Device>(id);
        }


        public void Post(Contract_Device obj)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(obj);
                transaction.Commit();
            }
        }

        public void Put(Contract_Device obj)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(obj);
                transaction.Commit();
            }
        }

        public void Delete(int id)
        {
            var obj = Get(id);
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(obj);
                transaction.Commit();
            }
        }
    }
}
