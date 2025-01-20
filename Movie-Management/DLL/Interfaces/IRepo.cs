using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    //public interface IRepo<CLASS, ID, RET>
    //{
    //    RET Create(CLASS obj);
    //    RET Update(CLASS obj);
    //    CLASS Get(ID id);
    //    List<CLASS> Get();
    //    bool Delete(ID id);

    //    // Optional additions
    //    List<CLASS> Search(string keyword); // General search method
    //    List<CLASS> FilterBy(Func<CLASS, bool> predicate); // Allows custom filtering
    //}
    public interface IRepo<T, TKey, TResult>
    {
        List<T> Get();
        T Get(TKey id);
        TResult Create(T obj);
        TResult Update(T obj);
        TResult Delete(TKey id);
    }
}
