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
        private ILibraryDbContext _context;
        private Repository<Book> _books;
        private Repository<BookQueue> _queuedBooks;
        private Repository<BorrowedBook> _borrowedBooks;
        public Repository<Book> Books
        {
            get
            {
                if (_books == null)
                {
                    _books = new Repository<Book>(_context);
                }

                return _books;
            }
        }

        public Repository<BookQueue> QueuedBooks
        {
            get
            {
                if (_queuedBooks == null)
                {
                    _queuedBooks = new Repository<BookQueue>(_context);
                }

                return _queuedBooks;
            }
        }

        public Repository<BorrowedBook> BorrowedBooks
        {
            get
            {
                if (_borrowedBooks == null)
                {
                    _borrowedBooks = new Repository<BorrowedBook>(_context);
                }

                return _borrowedBooks;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
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
