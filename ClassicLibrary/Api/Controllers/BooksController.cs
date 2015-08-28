using ClassicLibrary.DAL.Abstract;
using ClassicLibrary.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public string Get()
        {
            return "";
        }

        [HttpPost]
        public void Post(Book book)
        {
            if (ModelState.IsValid)
            {
                service.Books.Insert(book);
            }
        }
    }
}
