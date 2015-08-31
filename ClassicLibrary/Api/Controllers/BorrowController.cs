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
    public class BorrowController : ApiController
    {
        private IDataService service;

        public BorrowController(IDataService service)
        {
            this.service = service;
        }

        [HttpPost]
        public HttpResponseMessage Post(int id)
        {
            Book book = service.Books.GetById(id);
            if (book == null)
            {
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.NotFound, Content = new StringContent("Book not found in Library, please contact Administrator.") };
            }

            var currentUser = service.Users.Get(user => user.UserName == User.Identity.Name).FirstOrDefault();
            if (currentUser == null)
            {
                return new HttpResponseMessage() { StatusCode = HttpStatusCode.NotFound, Content = new StringContent("User not authenticated, please contact Administrator.") };
            }

            if (book.Quantity > book.Queued)
            {
                BorrowedBook borrowedBook = new BorrowedBook() { Book = book, User = currentUser, ReturnDate = DateTime.Today.AddMonths(1) };
                book.Queued += 1;
                service.BorrowedBooks.Insert(borrowedBook);
                service.Books.Update(book);
            }
            else
            {
                BookQueue queuedBook = new BookQueue() { AwaitedBook = book, AwaitingReader = currentUser };
                service.QueuedBooks.Insert(queuedBook);
            }

            service.Save();

            return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, Content = new StringContent("Book borrowed.") };
        }

        [HttpPost]
        public void Post(int id, bool queue)
        {

        }
    }
}
