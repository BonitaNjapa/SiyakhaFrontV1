using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate);
    }
}

