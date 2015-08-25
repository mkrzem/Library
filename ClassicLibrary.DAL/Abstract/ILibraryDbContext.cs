using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Abstract
{
    public interface ILibraryDbContext : IDisposable
    {
        IDbSet<T> Query<T>() where T : class;
        int SaveChanges();

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
