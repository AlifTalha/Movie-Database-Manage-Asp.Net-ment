
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos
{
    internal class WatchlistRepo : Repo, IWatchlistRepo
    {
        public bool Create(Watchlist obj)
        {
            db.Watchlists.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var watchlist = Get(id);
            if (watchlist != null)
            {
                db.Watchlists.Remove(watchlist);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public Watchlist Get(int id)
        {
            return db.Watchlists
                     .Include(w => w.Movie)
                     .Include(w => w.User)
                     .FirstOrDefault(w => w.Id == id);
        }

        public List<Watchlist> Get()
        {
            return db.Watchlists
                     .Include(w => w.Movie)
                     .Include(w => w.User)
                     .ToList();
        }

        public List<Watchlist> GetByUserId(int userId)
        {
            return db.Watchlists
                     .Where(w => w.UserId == userId)
                     .Include(w => w.Movie)
                     .Include(w => w.User)
                     .ToList();
        }
    }
}
