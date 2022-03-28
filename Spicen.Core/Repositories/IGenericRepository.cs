using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spicen.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        // productRepository.GetAll(x=>x.id>5).orderBy.toList()
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        // IQueryable run after toList()
        // productRepository.Where(x=>x.id>5).orderBy.toList()
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAysnc(T entity);

        Task AddRangeAysnc(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}
