using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        [Route("api/movie/all")]
        public HttpResponseMessage GetAllMovies()
        {
            var data = MovieService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/movie/{id}")]
        public HttpResponseMessage GetMovieById(int id)
        {
            var data = MovieService.Get(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Movie not found");
        }

        [HttpPost]
        [Route("api/movie/add")]
        public HttpResponseMessage AddMovie(MovieDTO movie)
        {
            var result = MovieService.Add(movie);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Movie added successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to add movie");
        }

        [HttpPut]
        [Route("api/movie/update/{id}")]
        public HttpResponseMessage UpdateMovie(int id, MovieDTO movie)
        {
            var result = MovieService.Update(id, movie);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Movie updated successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to update movie");
        }

        [HttpGet]
        [Route("api/movie/search")]
        public HttpResponseMessage SearchMovies(string query)
        {
            var data = MovieService.Search(query);
            if (data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No movies found matching the query");
        }


        [HttpDelete]
        [Route("api/movie/delete/{id}")]
        public HttpResponseMessage DeleteMovie(int id)
        {
            var result = MovieService.Delete(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Movie deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to delete movie");
        }
    }
}


//talha