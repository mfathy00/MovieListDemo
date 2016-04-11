using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieListDemo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MovieListDemo.Models.Tests
{
    [TestClass()]
    public class MovieTests
    {
        [TestMethod()]
        public void SearchMovieTest()
        {
            var testmovie = Movie.SearchMovie("rush hour 3");
            Assert.AreEqual(5174, testmovie[0].MovieID);
            Assert.AreEqual("https://image.tmdb.org/t/p/w185/qgaDWYLrnEPJpc5Lp35WbgX7GfS.jpg", testmovie[0].Poster);
            Assert.AreEqual("After an attempted assassination on Ambassador Han, Inspector Lee and Detective Carter are back in action as they head to Paris to protect a French woman with knowledge of the Triads' secret leaders. Lee also holds secret meetings with a United Nations authority, but his personal struggles with a Chinese criminal mastermind named Kenji, which reveals that it's Lee's long-lost...brother.", testmovie[0].Summary);
            Assert.AreEqual("Rush Hour 3", testmovie[0].Title);
            Assert.AreEqual("https://www.youtube.com/embed/sKf4ef4j6qQ", testmovie[0].URL);
        }
    }
}
