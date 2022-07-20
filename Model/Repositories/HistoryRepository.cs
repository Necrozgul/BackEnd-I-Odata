using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HistoryRepository : IHistoryRepository
    {
        RentalDBContextOLD db;
        public HistoryRepository(RentalDBContextOLD _db)
        {
            this.db = _db;
        }
        public IList<History> GetAll()
        {
            return db.History.ToArray();
        }
        public History Get(int id)
        {
            return db.History.FirstOrDefault(t => t.Id == id);
        }


        public void Post(History obj)
        {
            db.History.Add(obj);
            db.SaveChanges();
        }


        public void CleanHistory(int id)
        {
            foreach (var item in db.History)
            {
                db.History.Remove(item);
            }
        }



    }
}
