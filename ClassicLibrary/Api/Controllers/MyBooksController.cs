using ClassicLibrary.DAL.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace ClassicLibrary.Api.Controllers
{
    public class MyBooksController : ApiController
    {
        private IDataService service;

        public MyBooksController(IDataService service)
        {
            this.service = service;
        }  
        [Authorize]
        public HttpResponseMessage Get()
        {
            string response;

            if (!User.Identity.IsAuthenticated)
            {
                response = "You need to be logged in to see your books";
                return new HttpResponseMessage() { Content = new StringContent(response, Encoding.UTF8, "text/plain") };
            }

            var borrowedBooks = service.BorrowedBooks.Get(borrowed => borrowed.User.UserName.Equals(User.Identity.Name)).Select(b => b.Book);
            response = JsonConvert.SerializeObject(borrowedBooks);
            return new HttpResponseMessage() { Content = new StringContent(response, Encoding.UTF8, "application/json") };
        }
    }
}
