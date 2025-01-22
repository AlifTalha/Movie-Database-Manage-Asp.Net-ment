
using BLL.DTOs;
using BLL.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    public class ReviewController : ApiController
    {
        [HttpGet]
        [Route("api/review/movie/{movieId}")]
        public HttpResponseMessage GetReviewsByMovie(int movieId)
        {
            var reviews = ReviewService.GetByMovie(movieId);

          
            var response = reviews.Select(r => new
            {
                r.Id,
                r.Content,
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
        [Route("api/review/add")]
        public HttpResponseMessage AddReview(ReviewDTO review)
        {
            var result = ReviewService.Add(review);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Review added successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to add review");
        }

        [HttpDelete]
        [Route("api/review/delete/{id}")]
        public HttpResponseMessage DeleteReview(int id)
        {
            var result = ReviewService.Delete(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Review deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to delete review");
        }
    }
}
