using System.Configuration;
using TMDbLib.Client;

namespace MovieListDemo
{
    public class APIConfiguration
    {
      private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

      public static TMDbClient ConnectAPI() 
      {
          try
          {
             TMDbClient client = new TMDbClient(ConfigurationManager.AppSettings["ApiKey"]);
              return client;
          }
          catch (System.Exception ex)
          {
              logger.Error(ex.Message);
              throw;
          }
      }
    }
}