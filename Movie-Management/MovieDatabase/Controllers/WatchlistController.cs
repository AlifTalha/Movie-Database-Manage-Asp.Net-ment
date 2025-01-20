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
    public class WatchlistController : ApiController
    {
        [HttpGet]
        [Route("api/watchlist/user/{userId}")]
        public HttpResponseMessage GetWatchlistByUser(int userId)
        {
            var data = WatchlistService.GetByUser(userId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
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
