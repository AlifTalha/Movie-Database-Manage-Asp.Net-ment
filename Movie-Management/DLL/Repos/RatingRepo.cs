﻿using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class RatingRepo : Repo, IRepo<Rating, int, bool>
    {
        public bool Create(Rating obj)
        {
            db.Ratings.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var rating = Get(id);
            db.Ratings.Remove(rating);
            return db.SaveChanges() > 0;
        }

        public Rating Get(int id)
        {
            return db.Ratings.Find(id);
        }

        public List<Rating> Get()
        {
            return db.Ratings.ToList();
        }

        public bool Update(Rating obj)
        {
            var existingRating = Get(obj.Id);
            db.Entry(existingRating).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
