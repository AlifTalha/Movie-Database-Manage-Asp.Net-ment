using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class WatchlistRepo : Repo, IRepo<Watchlist, int, bool>
    {
        public bool Create(Watchlist obj)
        {
            db.Watchlists.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var watchlist = Get(id);
            db.Watchlists.Remove(watchlist);
            return db.SaveChanges() > 0;
        }

        public Watchlist Get(int id)
        {
            return db.Watchlists.Find(id);
        }

        public List<Watchlist> Get()
        {
            return db.Watchlists.ToList();
        }

        public bool Update(Watchlist obj)
        {
            var existingWatchlist = Get(obj.Id);
            db.Entry(existingWatchlist).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
