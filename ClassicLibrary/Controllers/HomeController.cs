using ClassicLibrary.DAL.Helpers;
using ClassicLibrary.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace ClassicLibrary.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetGenres()
        {
            return DataDetailsProvider.GetEnumerationAsJson<BookGenre>();
            //return new HttpResponseMessage() { Content = new StringContent(result, Encoding.UTF8, "text/plain") };      
        }
    }
}
