//using DAL.EF.Tables;
//using DAL.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DAL.Repos
//{
//    internal class UserRepo : Repo, IRepo<User, int, bool>
//    {
//        public bool Create(User obj)
//        {
//            db.Users.Add(obj);
//            return db.SaveChanges() > 0;
//        }

//        public bool Delete(int id)
//        {
//            var user = Get(id);
//            db.Users.Remove(user);
//            return db.SaveChanges() > 0;
//        }

//        public User Get(int id)
//        {
//            return db.Users.Find(id);
//        }

//        public List<User> Get()
//        {
//            return db.Users.ToList();
//        }

//        public bool Update(User obj)
//        {
//            var existingUser = Get(obj.Id);
//            db.Entry(existingUser).CurrentValues.SetValues(obj);
//            return db.SaveChanges() > 0;
//        }
//    }
//}




using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IUserRepo<User, int, bool>
    {
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = Get(id);
            db.Users.Remove(user);
            return db.SaveChanges() > 0;
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
            db.Entry(user).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public User GetByUsername(string username)
        {
            return db.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
