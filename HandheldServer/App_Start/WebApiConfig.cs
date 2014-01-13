using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HandheldServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithParameters",
                routeTemplate: "api/{controller}/{ID}/{CountToFetch}"
                //defaults: new { ID = RouteParameter.Optional, CountToFetch = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWith3Parameters",
                routeTemplate: "api/{controller}/{ID}/{packSize}/{CountToFetch}"
                //defaults: new { ID = RouteParameter.Optional, packSize = RouteParameter.Optional, CountToFetch = RouteParameter.Optional }
            );

            // TODO: Should I add entries here for all of the expected URIs?

        }
    }
}
