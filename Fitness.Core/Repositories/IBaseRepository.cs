using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Core.Repositories
{
    public interface IBaseRepository<T>
        where T: new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int Id);

        Task Create(T entity);

        Task Delete(int Id);

        Task Update(T entity);
    }
}
