using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    
    public interface IUserRepo<T, K, R> : IRepo<T, K, R>
    //{
    //    // Add user-specific methods if needed, e.g., searching users by email or username
    //    User GetByUsername(string username);
    //}
    {
        User GetByUsername(string username);
        User ValidateCredentials(string username, string password);
    }
}
