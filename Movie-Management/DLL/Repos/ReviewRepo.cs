
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL.Repos
{
    internal class ReviewRepo : Repo, IReviewRepo
    {
        public bool Create(Review obj)
        {
            db.Reviews.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var review = Get(id);
            db.Reviews.Remove(review);
            return db.SaveChanges() > 0;
        }

        public Review Get(int id)
        {
            return db.Reviews
                .Include(r => r.User)    
                .Include(r => r.Movie)   
                .FirstOrDefault(r => r.Id == id);
        }

        public List<Review> Get()
        {
            return db.Reviews
                .Include(r => r.User)    
                .Include(r => r.Movie)   
                .ToList();
        }

        public bool Update(Review obj)
        {
            var existingReview = Get(obj.Id);
            db.Entry(existingReview).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Review> GetByMovieId(int movieId)
        {
            return db.Reviews
                .Include(r => r.User)   
                .Include(r => r.Movie)  
                .Where(r => r.MovieId == movieId)
                .ToList();
        }
    }
}
