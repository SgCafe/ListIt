using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListIt.Repository
{
    public interface IDataRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<int> InsetAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(T item);

    }
}
