using System.Configuration;
using TMDbLib.Client;

namespace MovieListDemo
{
    public class APIConfiguration
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static TMDbClient _client;

        public static TMDbClient ConnectAPI()
        {
            try
            {
                if (_client == null)
                {
                    _client = new TMDbClient(ConfigurationManager.AppSettings["ApiKey"]);
                }
                return _client;
            }
            catch (System.Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}