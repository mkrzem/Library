using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Abstract
{
    public interface IRepository<TEntity>
    {
        bool Insert(TEntity entity);
        TEntity GetById(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
    }
}
