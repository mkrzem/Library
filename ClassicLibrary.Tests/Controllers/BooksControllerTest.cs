using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicLibrary.DAL.Model;
using ClassicLibrary.DAL.Helpers;
using ClassicLibrary.DAL.Abstract;
using ClassicLibrary.Tests.Concrete;
using ClassicLibrary.Api.Controllers;
using System.Net;

namespace ClassicLibrary.Tests.Controllers
{
    /// <summary>
    /// Summary description for BooksGenreControllerTest
    /// </summary>
    [TestClass]
    public class BooksControllerTest
    {
        private FakeUnitOfWork service;
        private BooksController booksController;

        [TestInitialize]
        public void Init()
        {
            service = new FakeUnitOfWork();
            booksController = new BooksController(service);        
        }
      
        [TestMethod]
        public void Add_Single_Book()
        {
            var newBook = new Book();

            var response = booksController.Post(newBook);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, (service.Books as FakeRepository<Book>).added.Count);
            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        public void Book_Found_By_Id()
        {
            InsertSingleBook();

            var response = booksController.Get(1);

            Assert.AreNotEqual("null", response);
        }

        [TestMethod]
        public void Book_NOT_Found_By_Id()
        {
            InsertSingleBook();

            var response = booksController.Get(13);
            string result = response.Content.ReadAsStringAsync().Result;

            Assert.AreEqual("null", result);
        }

        private void InsertSingleBook()
        {
            service.Books.Insert(new Book()
            {
                Author = "TestA",
                Genre = BookGenre.Action,
                Id = 1,
                Name = "TestN",
                Quantity = 2,
                Queued = 0,
                ReleaseDate = DateTime.Today.AddMonths(-1),
                Status = BookStatus.Available
            });
        }
    }

}
