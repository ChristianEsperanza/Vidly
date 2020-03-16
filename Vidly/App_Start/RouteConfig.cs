using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            /**Must define routes in order of most specific to most generic **/
            /**     Convention Routing:
             
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate"},
                //\d denotes digit, 4 represents num of repetitions
                //@ replaces double backslash
                new { year = @"\d{4}", month = @"\d{2}" }

                //This would set a tighter restriction:
                //new {year = @"2020|2021", month = @"\d{2}"}
                );

            **/

            routes.MapRoute(
                name: "Default",
                //If url has the following pattern, the first part of URL is the 
                //name of the controller, second is the action, the third is an ID 
                //which can be passed to that action
                url: "{controller}/{action}/{id}", 

                //If any value is missing, this is the default route that will be taken:
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
