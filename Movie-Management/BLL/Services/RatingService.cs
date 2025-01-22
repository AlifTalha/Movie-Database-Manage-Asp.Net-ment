
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class RatingService
    {
        
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Rating, RatingDTO>()
                   .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                   .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie));

                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Movie, MovieDTO>();

                cfg.CreateMap<RatingDTO, Rating>();
            });
            return new Mapper(config);
        }


        public static List<RatingDTO> GetByMovie(int movieId)
        {
            var repo = DataAccessFactory.RatingRepo();
            var ratings = repo.Get().Where(r => r.MovieId == movieId).ToList();
            return GetMapper().Map<List<RatingDTO>>(ratings);
        }

        public static bool Add(RatingDTO rating)
        {
            var repo = DataAccessFactory.RatingRepo();
            var entity = GetMapper().Map<Rating>(rating);
            return repo.Create(entity);
        }
    }
}
