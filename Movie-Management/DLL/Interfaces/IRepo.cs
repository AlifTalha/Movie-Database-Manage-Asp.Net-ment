using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    
    public interface IRepo<T, TKey, TResult>
    {
        List<T> Get();
        T Get(TKey id);
        TResult Create(T obj);
        TResult Update(T obj);
        TResult Delete(TKey id);
    }
}
