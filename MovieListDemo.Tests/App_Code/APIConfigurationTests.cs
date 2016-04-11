using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMDbLib.Client;

namespace MovieListDemo.Tests
{
    [TestClass()]
    public class APIConfigurationTests
    {
        [TestMethod()]
        public void ConnectAPITest1()
        {
            TMDbClient connect = APIConfiguration.ConnectAPI();
            Assert.AreEqual("45b8df4d5d3f51411eb77e2466d7f8f0", connect.ApiKey);
        }
    }
}
