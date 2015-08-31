using ClassicLibrary.DAL.Abstract;
using ClassicLibrary.DAL.Helpers;
using ClassicLibrary.DAL.Model;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ClassicLibrary.Api.Controllers
{
    public class BookGenreController : ApiController
    {
        private IDataService service;

        public BookGenreController(IDataService service)
        {
            this.service = service;
        }

        public HttpResponseMessage GetGenres()
        {
            string result = DataDetailsProvider.GetEnumerationAsJson<BookGenre>();
            return new HttpResponseMessage() { Content = new StringContent(result, Encoding.UTF8, "text/plain") };
        }
    }
}
