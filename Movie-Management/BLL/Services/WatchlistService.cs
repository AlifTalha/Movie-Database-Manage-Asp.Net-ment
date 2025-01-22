
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;

namespace BLL.Services
{
    public class WatchlistService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Watchlist, WatchlistDTO>()
                   .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                   .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<WatchlistDTO, Watchlist>();
            });
            return new Mapper(config);
        }

        public static List<WatchlistDTO> GetByUser(int userId)
        {
            var repo = DataAccessFactory.WatchlistRepo();
            var watchlist = repo.GetByUserId(userId);
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
