using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CG.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace CG.Domain.Repository
{
    public interface IRepositoryQuery<T> 
    {
        Task<T> Get(long id);

        Task<List<T>> GetAll();

        Task<(IEnumerable<T> results, int totalItems)> GetAllPaginated(int pageNumber, int pageSize,
            Expression<Func<T,bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enabledTraking = false,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
    }
}