using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HandheldServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //If get 404 error re: favicon, see http://docs.castleproject.org/(X(1)S(vv4c5o450lhlzb45p5wzrq45))/Windsor.Windsor-tutorial-part-two-plugging-Windsor-in.ashx or just uncomment the line below:
            //routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "DepartmentsController", action = "GetCountOfDepartmentRecords", id = UrlParameter.Optional }
                defaults: new { controller = "Departments", action = "GetCountOfDepartmentRecords", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Department",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "DepartmentsController", action = "GetCountOfDepartmentRecords", id = UrlParameter.Optional }
                defaults: new { controller = "Departments", action = "GetCountOfDepartmentRecords", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "Departments",
            //    url: "{controller}/{action}/{id}",
            //    //defaults: new { controller = "DepartmentsController", action = "GetCountOfDepartmentRecords", id = UrlParameter.Optional }
            //    defaults: new { controller = "Departments", action = "GetCountOfDepartmentRecords", id = UrlParameter.Optional }
            //);

            // According to http://stackoverflow.com/questions/20960690/how-do-i-get-web-api-castle-windsor-to-recognize-a-controller/20970371?noredirect=1#20970371
            // should use MapHttpRoute instead:
            //config.routes.MapHttpRoute(
            //    name: "Departments",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Departments", action = "GetCountOfDepartmentRecords", id = UrlParameter.Optional }
            //);

        }
    }
}
