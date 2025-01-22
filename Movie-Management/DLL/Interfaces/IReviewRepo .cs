
using DAL.EF.Tables;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IReviewRepo : IRepo<Review, int, bool>
    {
        List<Review> GetByMovieId(int movieId);
    }
}
