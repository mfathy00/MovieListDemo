using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;

namespace MovieListDemo.Controllers
{
    public class HomeController : Controller
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        [OutputCache(Duration = 10)]
        public ActionResult Index(string title, int? page)
        {
            try
            {
                List<Models.Movie> mlist = Models.Movie.SearchMovie(title);
                if (!String.IsNullOrEmpty(title))
                {
                    page = 1;
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(mlist.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }
    }
}
