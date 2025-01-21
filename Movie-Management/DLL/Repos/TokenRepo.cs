
using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class TokenRepo : Repo, IRepo<Token, int, bool>
    {
        public bool Create(Token obj)
        {
            db.Tokens.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var token = Get(id);
            if (token != null)
            {
                db.Tokens.Remove(token);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public bool Update(Token obj)
        {
            var token = Get(obj.Id);
            if (token != null)
            {
                db.Entry(token).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool InvalidateToken(string tokenKey)
        {
           
            var token = db.Tokens.FirstOrDefault(t => t.Key == tokenKey);

            if (token != null)
            {
              
                db.Tokens.Remove(token);

            
                return db.SaveChanges() > 0;
            }

           
            return false;
        }



    }
}
