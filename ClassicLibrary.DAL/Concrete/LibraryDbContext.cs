using ClassicLibrary.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using ClassicLibrary.DAL.Model;

namespace ClassicLibrary.DAL.Concrete
{
    public class LibraryDbContext : IdentityDbContext, ILibraryDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookQueue> QueuedBooks { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public LibraryDbContext()
            : base("ClassicLibraryDbContext")
        {
        }

        public static LibraryDbContext Create()
        {
            return new LibraryDbContext();
        }
        public IDbSet<T> Query<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
