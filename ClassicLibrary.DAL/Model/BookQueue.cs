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
        public Book AwaitedBook { get; set; }
        public ApplicationUser AwaitingReader { get; set; }
        public int Position { get; set; }
    }
}
