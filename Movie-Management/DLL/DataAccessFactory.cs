using DAL.EF.Tables;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DataAccessFactory
    {
        public static IUserRepo<User, int, bool> UserRepo()
        {
            return new UserRepo();
        }

        public static IRepo<Movie, int, bool> MovieRepo()
        {
            return new MovieRepo();
        }

        public static IRepo<Review, int, bool> ReviewRepo()
        {
            return new ReviewRepo();
        }

        public static IRepo<Rating, int, bool> RatingRepo()
        {
            return new RatingRepo();
        }

        public static IRepo<Watchlist, int, bool> WatchlistRepo()
        {
            return new WatchlistRepo();
        }
    }
}
