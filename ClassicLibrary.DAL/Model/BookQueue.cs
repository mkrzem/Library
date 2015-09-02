using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Model
{
    public class BookQueue
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Book AwaitedBook { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser AwaitingReader { get; set; }
        public int Position { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
