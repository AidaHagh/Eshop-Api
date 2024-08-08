using Common.Domain;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure._Utilities
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ShopContext Context;
        public BaseRepository(ShopContext context)
        {
            Context = context;
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await Context.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public async Task AddRange(ICollection<TEntity> entities, CancellationToken cancellationToken)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().Any(expression);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return await Context.Set<TEntity>().AnyAsync(expression, cancellationToken);
        }

        public TEntity? Get(long id)
        {
            return Context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id)); ;
        }

        public virtual async Task<TEntity?> GetAsync(long id, CancellationToken cancellationToken)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id), cancellationToken); ;
        }

        public async Task<TEntity?> GetTracking(long id, CancellationToken cancellationToken)
        {
            return await Context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id), cancellationToken);
        }

        public async Task<int> Save()
        {
            return await Context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }
    }
}
