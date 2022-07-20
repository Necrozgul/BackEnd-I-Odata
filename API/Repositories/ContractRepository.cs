using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ContractRepository : IContractRepository
    {
        public IList<Contract> GetAll()
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            {
                var Contracts = session
                    .CreateCriteria(typeof(Contract))
                    .List<Contract>();
                return Contracts;
            }
        }
        public Contract Get(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
                return session.Get<Contract>(id);
        }


        public void Post(Contract obj)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(obj);
                transaction.Commit();
            }
        }

        public void Put(Contract obj)
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
