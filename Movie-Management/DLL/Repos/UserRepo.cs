


using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class UserRepo : Repo, IUserRepo<User, int, bool>
    {
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = Get(id);
            if (user != null)
            {
                db.Users.Remove(user);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public bool Update(User obj)
        {
            var user = Get(obj.Id);
            if (user != null)
            {
                db.Entry(user).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public User GetByUsername(string username)
        {
            return db.Users.FirstOrDefault(u => u.Username == username);
        }

        public User ValidateCredentials(string username, string password)
        {
            return db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
