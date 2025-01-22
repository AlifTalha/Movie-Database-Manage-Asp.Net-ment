
using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;

namespace BLL.Services
{
    public class MovieService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<MovieDTO, Movie>();
            });
            return new Mapper(config);
        }

        public static List<MovieDTO> Get()
        {
            var repo = DataAccessFactory.MovieRepo();
            return GetMapper().Map<List<MovieDTO>>(repo.Get());
        }

        public static MovieDTO Get(int id)
        {
            var repo = DataAccessFactory.MovieRepo();
            var movie = repo.Get(id);
            return GetMapper().Map<MovieDTO>(movie);
        }

        public static bool Add(MovieDTO movie)
        {
            var repo = DataAccessFactory.MovieRepo();
            var entity = GetMapper().Map<Movie>(movie);
            return repo.Create(entity);
        }

        public static bool Update(int id, MovieDTO movie)
        {
            var repo = DataAccessFactory.MovieRepo();
            var entity = GetMapper().Map<Movie>(movie);
            entity.Id = id; 
            return repo.Update(entity);
        }

        public static List<MovieDTO> Search(string query)
        {
            var repo = DataAccessFactory.MovieRepo();
            var movies = repo.Search(query);
            return GetMapper().Map<List<MovieDTO>>(movies);
        }



        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.MovieRepo();
            return repo.Delete(id);
        }
    }
}
