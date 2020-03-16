using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            //Creating instance of Movie model
            var movie = new Movie() { Name = "Shrek" , ID = 0};

            /**
              The following are irrelevant and a hassle as you 
              have to change them in Random.cshtml as well. Just 
              use the above line and pass movie into View();
            **/
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            var customers = new List<Customer>
            {
                new Customer {Name = "Cust1"},
                new Customer {Name = "Cust2"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };



            //Returns the movie model
            return View(viewModel);
        }

        //Parameter is embedded in the url
        public ActionResult Edit(int movieId)
        {
            return Content("id=" + movieId);
        }        
        
        /** ? = nullable integer
         * String in C# is reference type and nullable by default
         * If you go to /movies in the url, you are given default values. These 
         * default values can be overridden by specifying the parameters in 
         * the URL. For example:
         *      /movies?pageIndex=5&sortBy=ReleaseDate
         * 
         * However, will want a route with multiple parameters
         */
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        /**
         * This adds ActionResult specifies movies by release date
         * with the url parameter given being
         *      movies/released/{year passed in}/{month passed in}
         * The constraints for digit length are placed in routeConfig for 
         * Convention Routing.
         * 
         * Attribute Routing []
         */

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        
    }
}