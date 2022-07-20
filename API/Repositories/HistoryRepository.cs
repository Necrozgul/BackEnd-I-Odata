using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class HistoryRepository : IHistoryRepository
    {
        public IList<History> GetAll()
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            {
                var Historys = session
                    .CreateCriteria(typeof(History))
                    .List<History>();
                return Historys;
            }
        }
        public History Get(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
                return session.Get<History>(id);
        }


        public void Post(History obj)
        {
            using (NHibernate.ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(obj);
                transaction.Commit();
            }
        }




    }
}
