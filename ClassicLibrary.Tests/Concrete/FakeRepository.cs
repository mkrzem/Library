using ClassicLibrary.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ClassicLibrary.Tests.Concrete
{
    public class FakeRepository<TEntity> : IRepository<TEntity>
    {
        private List<TEntity> set;
        public List<TEntity> added = new List<TEntity>();
        public List<TEntity> deleted = new List<TEntity>();
        public List<TEntity> updated = new List<TEntity>();

        public FakeRepository(List<TEntity> set)
        {
            this.set = set;
        }
        public void Delete(TEntity entity)
        {
            set.Remove(entity);
            deleted.Add(entity);
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return set.Where(filter.Body as Func<TEntity, bool>).ToList();
            }

            return set;
        }

        public TEntity GetById(int id)
        {
            Type type = typeof(TEntity);
            return set.Where(entity => type.GetProperty("Id").GetValue(entity).Equals(id)).FirstOrDefault();
        }

        public bool Insert(TEntity entity)
        {
            set.Add(entity);
            added.Add(entity);
            return true;
        }

        public void Update(TEntity entity)
        {
            updated.Add(entity);
        }


    }
}
