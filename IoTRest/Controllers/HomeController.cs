using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoTRest.Controllers
{
    public class HomeController : Controller
    {
        IFOO _foo = null;
        //public HomeController(IFOO foo)
        //{
        //    _foo = foo;
        //}

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
