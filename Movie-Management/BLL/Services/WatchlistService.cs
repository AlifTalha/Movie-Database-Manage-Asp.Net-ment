//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BLL.Services
//{
//    internal class WatchlistService
//    {
//    }
//}


using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class WatchlistService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Watchlist, WatchlistDTO>();
                cfg.CreateMap<WatchlistDTO, Watchlist>();
            });
            return new Mapper(config);
        }

        public static List<WatchlistDTO> GetByUser(int userId)
        {
            var repo = DataAccessFactory.WatchlistRepo();
            var watchlist = repo.Get().Where(w => w.UserId == userId).ToList();
            return GetMapper().Map<List<WatchlistDTO>>(watchlist);
        }

        public static bool Add(WatchlistDTO watchlist)
        {
            var repo = DataAccessFactory.WatchlistRepo();
            var entity = GetMapper().Map<Watchlist>(watchlist);
            return repo.Create(entity);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.WatchlistRepo();
            return repo.Delete(id);
        }
    }
}
