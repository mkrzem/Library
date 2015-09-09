using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassicLibrary.DAL.Helpers;
using ClassicLibrary.DAL.Model;

namespace ClassicLibrary.Tests.Helpers
{
    /// <summary>
    /// Summary description for DataDetailsProviderTest
    /// </summary>
    [TestClass]
    public class DataDetailsProviderTest
    {       
        [TestMethod]
        public void Enumeration_Returned_As_Json()
        {
            string testEnumResult = DataDetailsProvider.GetEnumerationAsJson<DetailsProviderTestEnum>();
            string bookGenreResult = DataDetailsProvider.GetEnumerationAsJson<BookGenre>();
            //var bookGenreController = new BookGenreController();
            //string result = bookGenreController.GetGenres().Content.;
            Assert.AreEqual("[{\"Value\":0,\"Name\":\"First\"},{\"Value\":1,\"Name\":\"Second\"},{\"Value\":2,\"Name\":\"Third\"}]", testEnumResult);
            Assert.AreEqual("[{\"Value\":0,\"Name\":\"Drama\"},{\"Value\":1,\"Name\":\"Action\"},{\"Value\":2,\"Name\":\"Crime\"}," 
                + "{\"Value\":3,\"Name\":\"SciFi\"},{\"Value\":4,\"Name\":\"Fantasy\"},{\"Value\":5,\"Name\":\"Classical\"}]", bookGenreResult);
            //
            // TODO: Add test logic here
            //
        }
    }

    enum DetailsProviderTestEnum
    {
        First = 0,
        Second = 1,
        Third = 2
    };
}
