using System;
using CG.Domain.Entities;
using CG.Domain.Repository;
using CG.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CG.Domain.Entities.EntitiesBase;
using Microsoft.EntityFrameworkCore.Query;

namespace CG.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApplicationDbContext DbContext;

        public Repository(ApplicationDbContext context)
        {
            DbContext = context;
        }

        public async Task Add(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await DbContext.Set<T>().AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Set<T>().Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var entity = await Get(id);
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public Task<T> Get(long id) => DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<T>> GetAll() => DbContext.Set<T>().ToListAsync();

        public async Task<(IEnumerable<T> results, int totalItems)> GetAllPaginated(int pageNumber, int pageSize,
            Expression<Func<T,bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool enabledTraking = false,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = DbContext.Set<T>();

            if (!enabledTraking)
            {
                query.AsNoTracking();
            }

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            if (include is not null)
            {
                query = include(query);
            }

            if (orderBy is not null)
            {
                query = orderBy(query);
            }

            var pagedList = (await query.Skip(pageSize * pageNumber).Take(pageSize).ToListAsync(),
                    await query.CountAsync());

            return pagedList;
        }
    }
}
