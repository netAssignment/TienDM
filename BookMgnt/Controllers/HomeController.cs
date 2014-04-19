using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookMgnt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "F-Town - SHTP.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Doan Minh Tien";

            return View();
        }
    }
}