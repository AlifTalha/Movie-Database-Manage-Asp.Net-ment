using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFavoriteRepo
    {
        bool Add(Favorite favorite);
        bool Remove(int id);
        Favorite Get(int id);
        List<Favorite> Get();
        List<Favorite> GetByUserId(int userId);
    }
}
