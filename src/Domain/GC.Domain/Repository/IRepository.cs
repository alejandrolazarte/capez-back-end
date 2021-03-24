using CG.Domain.Entities;

namespace CG.Domain.Repository
{
    public interface IRepository<T> : IRepositoryPersistence<T>,
        IRepositoryQuery<T> where T : EntityBase
    {
    }
}
