using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IBusinessManager
{
    public interface IGenericManager<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> InsertAsync(T obj);
        Task<T> InsertAllAsync(ICollection<T> obj);
        Task<T> UpdateAsync(T obj, object key);
        Task<int> DeleteAsync(T obj);
    }
}
