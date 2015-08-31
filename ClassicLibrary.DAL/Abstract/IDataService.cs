﻿using ClassicLibrary.DAL.Concrete;
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
        Repository<Book> Books { get; }
        Repository<BookQueue> QueuedBooks { get; }
        Repository<BorrowedBook> BorrowedBooks { get; }
        Repository<ApplicationUser> Users { get; }
        void Save();

    }
}
