using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HandheldServer.Models;

namespace HandheldServer.Controllers
{
    ////public class HomeController : Controller
    //public class HomeController : ApiController
    //{
    //    //public ActionResult Index()
    //    //{
    //    //    //ViewBag.Title = "Home Page";

    //    //    return View();
    //    //}
    //}
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
