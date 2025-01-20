using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MovieRepo : Repo, IRepo<Movie, int, bool>
    {
        public bool Create(Movie obj)
        {
            db.Movies.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var movie = Get(id);
            db.Movies.Remove(movie);
            return db.SaveChanges() > 0;
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public bool Update(Movie obj)
        {
            var existingMovie = Get(obj.Id);
            db.Entry(existingMovie).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
