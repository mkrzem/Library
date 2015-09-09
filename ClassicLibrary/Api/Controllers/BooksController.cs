using ClassicLibrary.DAL.Abstract;
using ClassicLibrary.DAL.Model;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Linq;
using System;

namespace ClassicLibrary.Api.Controllers
{    
    public class BooksController : ApiController
    {
        private IDataService service;
        public BooksController(IDataService service)
        {
            this.service = service;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            string result = JsonConvert.SerializeObject(service.Books.Get());
            return new HttpResponseMessage() { Content = new StringContent(result, Encoding.UTF8, "application/json") };
        }

        public HttpResponseMessage Get(int id)
        {
            string result = JsonConvert.SerializeObject(service.Books.GetById(id));
            return new HttpResponseMessage() { Content = new StringContent(result, Encoding.UTF8, "application/json") };
        }

        [HttpPost]
        public HttpResponseMessage Post(Book book)
        {
            var response = new HttpResponseMessage();
            if (ModelState.IsValid)
            {
                book.ReleaseDate = DateTime.Now.AddMonths(-1);
                service.Books.Insert(book);
                service.Save();
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StringContent("Book added.", Encoding.UTF8, "text/plain");
            }
            else
            {
                response.StatusCode = HttpStatusCode.Conflict;
                response.Content = new StringContent("Invalid data.", Encoding.UTF8, "text/plain");
            }

            return response;
        }
    }
}
