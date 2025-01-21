
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ReviewService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Review, ReviewDTO>();
                cfg.CreateMap<ReviewDTO, Review>();
            });
            return new Mapper(config);
        }

        public static List<ReviewDTO> GetByMovie(int movieId)
        {
            var repo = DataAccessFactory.ReviewRepo();
            var reviews = repo.Get().Where(r => r.MovieId == movieId).ToList();
            return GetMapper().Map<List<ReviewDTO>>(reviews);
        }

        public static bool Add(ReviewDTO review)
        {
            var repo = DataAccessFactory.ReviewRepo();
            var entity = GetMapper().Map<Review>(review);
            return repo.Create(entity);
        }

        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.ReviewRepo();
            return repo.Delete(id);
        }
    }
}
