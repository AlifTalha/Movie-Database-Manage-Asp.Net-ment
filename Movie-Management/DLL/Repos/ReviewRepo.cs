using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReviewRepo : Repo, IRepo<Review, int, bool>
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
            return db.Reviews.Find(id);
        }

        public List<Review> Get()
        {
            return db.Reviews.ToList();
        }

        public bool Update(Review obj)
        {
            var existingReview = Get(obj.Id);
            db.Entry(existingReview).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
