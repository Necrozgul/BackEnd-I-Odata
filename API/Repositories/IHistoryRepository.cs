using System.Collections.Generic;

namespace API
{
    public interface IHistoryRepository
    {
        History Get(int id);
        IList<History> GetAll();
        void Post(History obj);
    }
}