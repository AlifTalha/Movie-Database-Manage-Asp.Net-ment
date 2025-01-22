using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FavoriteService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Favorite, FavoriteDTO>()
                   .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                   .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<FavoriteDTO, Favorite>();
            });
            return new Mapper(config);
        }

        public static List<FavoriteDTO> GetByUser(int userId)
        {
            var repo = DataAccessFactory.FavoriteRepo();
            var favorites = repo.GetByUserId(userId);
            return GetMapper().Map<List<FavoriteDTO>>(favorites);
        }

        public static bool Add(FavoriteDTO favorite)
        {
            var repo = DataAccessFactory.FavoriteRepo();
            var entity = GetMapper().Map<Favorite>(favorite);
            return repo.Add(entity);
        }

        public static bool Remove(int id)
        {
            var repo = DataAccessFactory.FavoriteRepo();
            return repo.Remove(id);
        }
    }
}
