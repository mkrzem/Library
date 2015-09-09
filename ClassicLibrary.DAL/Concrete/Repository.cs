using ClassicLibrary.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private ILibraryDbContext _context;
        private DbSet<TEntity> _dbSet;
        
        public Repository(ILibraryDbContext context)
        {
            _context = context;
            _dbSet = (DbSet<TEntity>)context.Query<TEntity>();
        }
        public bool Insert(TEntity entity)
        {
            bool inserted = false;

            if (entity != null)
            {
                _dbSet.Add(entity);
                inserted = true;
            }

            return inserted;
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            if (_context.Entry<TEntity>(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }
    }
}
