using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using MovieListDemo;
using PagedList;

namespace MovieListDemo.Controllers
{
    public class HomeController : Controller
    {  
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        [OutputCache(Duration=10)]
        public ActionResult Index(string title, int? page)
        {
            /* Package use for that application  
             * SlowCheetah for config fils transform 
             * NLog For logging errors 
             * TMDbLib for TMDb Library wrapper for The Movie Database's API https://www.themoviedb.org/
             * PagedList.Mvc for mvc paging
             * site live on that site http://movielistdemo.apphb.com/
             * 
            */
            try
            {
                List<Models.Movie> mlist = Models.Movie.SearchMovie(title);
                if (title != null)
                {
                    page = 1;
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(mlist.ToPagedList(pageNumber, pageSize));

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }
    }
}
