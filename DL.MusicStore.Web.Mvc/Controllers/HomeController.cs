using DL.MusicStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DL.MusicStore.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // This is just for demo purpose
        public ActionResult Index()
        {
            return View();
        }
    }
}