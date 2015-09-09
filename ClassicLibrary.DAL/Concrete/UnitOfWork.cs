using ClassicLibrary.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicLibrary.DAL.Model;

namespace ClassicLibrary.DAL.Concrete
{
    public class UnitOfWork : IDataService
    {
        private bool disposed = false;
        private ILibraryDbContext context;
        private IRepository<Book> books;
        private IRepository<BookQueue> queuedBooks;
        private IRepository<BorrowedBook> borrowedBooks;
        private IRepository<ApplicationUser> users;

        public UnitOfWork(ILibraryDbContext context)
        {
            this.context = context;
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                if (users == null)
                {
                    users = new Repository<ApplicationUser>(context);
                }

                return users;
            }
        }
        public IRepository<Book> Books
        {
            get
            {
                if (books == null)
                {
                    books = new Repository<Book>(context);
                }

                return books;
            }
        }

        public IRepository<BookQueue> QueuedBooks
        {
            get
            {
                if (queuedBooks == null)
                {
                    queuedBooks = new Repository<BookQueue>(context);
                }

                return queuedBooks;
            }
        }

        public IRepository<BorrowedBook> BorrowedBooks
        {
            get
            {
                if (borrowedBooks == null)
                {
                    borrowedBooks = new Repository<BorrowedBook>(context);
                }

                return borrowedBooks;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                context.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
