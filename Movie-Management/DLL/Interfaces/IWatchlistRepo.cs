
using DAL.EF.Tables;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IWatchlistRepo
    {
        bool Create(Watchlist obj);
        bool Delete(int id);
        Watchlist Get(int id);
        List<Watchlist> Get();
        List<Watchlist> GetByUserId(int userId);
    }
}

