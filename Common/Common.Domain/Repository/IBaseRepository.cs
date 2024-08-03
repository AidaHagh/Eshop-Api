using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetAsync(long id, CancellationToken cancellationToken);

        Task<T?> GetTracking(long id, CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);
        void Add(T entity);

        Task AddRange(ICollection<T> entities, CancellationToken cancellationToken);

        void Update(T entity);

        Task<int> Save();

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);

        bool Exists(Expression<Func<T, bool>> expression);

        T? Get(long id);
    }
}
