
using BLL.DTOs;
using BLL.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    public class WatchlistController : ApiController
    {
        [HttpGet]
        [Route("api/watchlist/user/{userId}")]
        public HttpResponseMessage GetWatchlistByUser(int userId)
        {
            var watchlist = WatchlistService.GetByUser(userId);

            var response = watchlist.Select(w => new
            {
                w.Id,
                w.UserId,
                w.MovieId,
                Movie = w.Movie != null ? new
                {
                    w.Movie.Id,
                    w.Movie.Title,
                    w.Movie.Genre
                } : null,
                User = w.User != null ? new
                {
                    w.User.Id,
                    w.User.Username,
                    w.User.Email
                } : null
            });

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("api/watchlist/add")]
        public HttpResponseMessage AddToWatchlist(WatchlistDTO watchlist)
        {
            var result = WatchlistService.Add(watchlist);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Added to watchlist successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to add to watchlist");
        }

        [HttpDelete]
        [Route("api/watchlist/remove/{id}")]
        public HttpResponseMessage RemoveFromWatchlist(int id)
        {
            var result = WatchlistService.Delete(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Removed from watchlist successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to remove from watchlist");
        }
    }
}
