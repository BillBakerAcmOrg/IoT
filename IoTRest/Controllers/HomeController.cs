using log4net;
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
        ILog _log = null;

        public HomeController(IFOO foo, ILog log)
        {
            _foo = foo;
            _log = log;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            _log.Debug("this is the test message");

            return View();
        }
    }
}
