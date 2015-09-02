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
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
