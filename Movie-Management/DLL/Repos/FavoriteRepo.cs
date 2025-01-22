using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FavoriteRepo : Repo, IFavoriteRepo
    {
        public bool Add(Favorite favorite)
        {
            db.Favorites.Add(favorite);
            return db.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            var favorite = Get(id);
            if (favorite != null)
            {
                db.Favorites.Remove(favorite);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public Favorite Get(int id)
        {
            return db.Favorites
                     .Include(f => f.Movie)
                     .Include(f => f.User)
                     .FirstOrDefault(f => f.Id == id);
        }

        public List<Favorite> Get()
        {
            return db.Favorites
                     .Include(f => f.Movie)
                     .Include(f => f.User)
                     .ToList();
        }

        public List<Favorite> GetByUserId(int userId)
        {
            return db.Favorites
                     .Where(f => f.UserId == userId)
                     .Include(f => f.Movie)
                     .Include(f => f.User)
                     .ToList();
        }
    }
}
