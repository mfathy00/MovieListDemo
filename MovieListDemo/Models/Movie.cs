using System;
using System.Collections.Generic;
using System.Configuration;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using System.Data.Entity;


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
                SearchContainer<SearchMovie> results = APIConfiguration.ConnectAPI().SearchMovie("star wars");
                List<Models.Movie> mlist = new List<Models.Movie>();

                if (!String.IsNullOrEmpty(title))
                {
                    results = APIConfiguration.ConnectAPI().SearchMovie(title);
                }

                foreach (SearchMovie result in results.Results)
                {
                    TMDbLib.Objects.Movies.Movie trial = APIConfiguration.ConnectAPI().GetMovie(result.Id, MovieMethods.Videos);

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
        // That code apply in case we need to save result to Database 
        //public static DbSet<Movie> SaveToDB(List<Models.Movie> movielist) 
        //{
        //    var db = new MovieListDemo.Models.MovieContext();

        //    try
        //    {
        //        foreach (var item in movielist)
        //        {
        //            db.Movie.Add(item);
        //            db.SaveChanges();
        //        }
        //        return db.Movie;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex);
        //        throw;
        //    }
 
        //}
    }

}