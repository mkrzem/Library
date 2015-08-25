using ClassicLibrary.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace ClassicLibrary.DAL.Concrete
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public IDbSet<T> Query<T>() where T : class
        {
            return Set<T>();
        }
        
    }
}
