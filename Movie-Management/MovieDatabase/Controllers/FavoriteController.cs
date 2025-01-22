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
    public class FavoriteController : ApiController
    {
        [HttpGet]
        [Route("api/favorite/user/{userId}")]
        public HttpResponseMessage GetFavoritesByUser(int userId)
        {
            var favorites = FavoriteService.GetByUser(userId);

            var response = favorites.Select(f => new
            {
                f.Id,
                f.UserId,
                f.MovieId,
                Movie = f.Movie != null ? new
                {
                    f.Movie.Id,
                    f.Movie.Title,
                    f.Movie.Genre
                } : null,
                User = f.User != null ? new
                {
                    f.User.Id,
                    f.User.Username,
                    f.User.Email
                } : null
            });

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/favorite/add")]
        public HttpResponseMessage AddToFavorite(FavoriteDTO favorite)
        {
            var result = FavoriteService.Add(favorite);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Added to favorites successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to add to favorites");
        }

        [HttpDelete]
        [Route("api/favorite/remove/{id}")]
        public HttpResponseMessage RemoveFromFavorite(int id)
        {
            var result = FavoriteService.Remove(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Removed from favorites successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to remove from favorites");
        }
    }
}
