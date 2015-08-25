using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicLibrary.DAL.Model
{
    public enum BookGenre
    {
        Drama,
        Action,
        Crime,
        SciFi,
        Fantasy,
        Classical
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BookGenre Genre { get; set; }
        public string Author { get; set; }
    }
}
    
