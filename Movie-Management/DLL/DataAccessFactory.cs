
using DAL.EF.Tables;
using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;

namespace DAL
{
    public static class DataAccessFactory
    {
        //public static IUserRepo<User, int, bool> UserRepo()
        //{
        //    return new UserRepo();
        //}

        public static IMovieRepo MovieRepo()
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

        // Add TokenRepo method
        //public static IRepo<Token, int, bool> TokenRepo()
        //{
        //    return new TokenRepo();
        //}
        public static IUserRepo UserData()
        {
            return new UserRepo();
        }

    }
}
