using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Model
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Book Book { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
