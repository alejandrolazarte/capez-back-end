using CG.Domain.Entities;
using CG.Domain.Entities.EntitiesBase;

namespace CG.Domain.Repository
{
    public interface IRepository<T> : IRepositoryPersistence<T>,
        IRepositoryQuery<T> where T : EntityBase
    {
    }
}
