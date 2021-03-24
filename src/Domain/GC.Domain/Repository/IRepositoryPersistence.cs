using System.Collections.Generic;
using System.Threading.Tasks;
using CG.Domain.Entities;

namespace CG.Domain.Repository
{
    public interface IRepositoryPersistence<in T> where T: EntityBase
    {
        Task Add(T entity);

        Task AddRange(IEnumerable<T> entities);

        Task Update(T entity);

        Task Delete(long id);
    }
}
