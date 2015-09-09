using ClassicLibrary.DAL.Concrete;
using ClassicLibrary.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Abstract
{
    public interface IDataService: IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<BookQueue> QueuedBooks { get; }
        IRepository<BorrowedBook> BorrowedBooks { get; }
        IRepository<ApplicationUser> Users { get; }
        void Save();

    }
}
