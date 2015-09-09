using System;
using ClassicLibrary.DAL.Abstract;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Collections.Generic;

namespace ClassicLibrary.Tests.Concrete
{
    public class FakeLibraryDbContext : ILibraryDbContext
    {
        private Dictionary<Type, object> Sets;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IDbSet<T> Query<T>() where T : class
        {
            return Sets[typeof(T)] as IDbSet<T>;
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
