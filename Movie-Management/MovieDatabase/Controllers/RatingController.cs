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
    public class RatingController : ApiController
    {
        
        [HttpGet]
        [Route("api/rating/movie/{movieId}")]
        public HttpResponseMessage GetRatingsByMovie(int movieId)
        {
            var ratings = RatingService.GetByMovie(movieId);

           
            var response = ratings.Select(r => new
            {
                r.Id,
                r.Score,
                r.UserId,
                User = r.User != null ? new
                {
                    r.User.Id,
                    r.User.Username,
                    r.User.Email
                } : null,
                r.MovieId,
                Movie = r.Movie != null ? new
                {
                    r.Movie.Id,
                    r.Movie.Title,
                    r.Movie.Genre
                } : null
            });

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [HttpPost]
        [Route("api/rating/add")]
        public HttpResponseMessage AddRating(RatingDTO rating)
        {
            var result = RatingService.Add(rating);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Rating added successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to add rating");
        }
    }
}
