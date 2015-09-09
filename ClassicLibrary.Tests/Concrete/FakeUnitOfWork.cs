using ClassicLibrary.DAL.Abstract;
using System;
using System.Collections.Generic;
using ClassicLibrary.DAL.Model;

namespace ClassicLibrary.Tests.Concrete
{
    public class FakeUnitOfWork : IDataService
    {
        private bool saved = false;
        private FakeRepository<Book> books;
        private FakeRepository<BorrowedBook> borrowedBooks;
        private FakeRepository<BookQueue> queuedBooks;
        private FakeRepository<ApplicationUser> users;
        public IRepository<Book> Books
        {
            get
            {
                if (books == null)
                {
                    books = new FakeRepository<Book>(new List<Book>());
                }
                return books;
            }
        }

        public IRepository<BorrowedBook> BorrowedBooks
        {
            get
            {
                if (borrowedBooks == null)
                {
                    borrowedBooks = new FakeRepository<BorrowedBook>(new List<BorrowedBook>());
                }
                return borrowedBooks;
            }
        }

        public IRepository<BookQueue> QueuedBooks
        {
            get
            {
                if (queuedBooks == null)
                {
                    queuedBooks = new FakeRepository<BookQueue>(new List<BookQueue>());
                }
                return queuedBooks;
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                if (users == null)
                {
                    users = new FakeRepository<ApplicationUser>(new List<ApplicationUser>());
                }
                return users;
            }
        }

        public void Dispose()
        {
            
        }

        public void Save()
        {
            saved = true;
        }
    }
}
