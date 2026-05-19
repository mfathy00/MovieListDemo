using System;
using System.Collections.Generic;
using System.Configuration;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace MovieListDemo.Models
{
    public class Movie
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public int ID { get; set; }
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Poster { get; set; }
        public string Summary { get; set; }
        public string Language { get; set; }

        public static List<Models.Movie> SearchMovie(string title)
        {
            try
            {
                TMDbClient client = APIConfiguration.ConnectAPI();
                string searchTerm = String.IsNullOrEmpty(title) ? "star wars" : title;
                SearchContainer<SearchMovie> results = client.SearchMovie(searchTerm);
                List<Models.Movie> mlist = new List<Models.Movie>();

                foreach (SearchMovie result in results.Results)
                {
                    TMDbLib.Objects.Movies.Movie trial = client.GetMovie(result.Id, MovieMethods.Videos);

                    Models.Movie movie = new Models.Movie()
                    {
                        MovieID = result.Id,
                        Poster = ConfigurationManager.AppSettings["PosterPath"] + result.PosterPath,
                        Summary = result.Overview,
                        Title = result.Title,
                        URL = trial.Videos.Results.Count > 0 ? ConfigurationManager.AppSettings["YouTubePath"] + trial.Videos.Results[0].Key : ConfigurationManager.AppSettings["YouTubePath"]
                    };
                    mlist.Add(movie);
                }
                return mlist;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }

}