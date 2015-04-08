using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("About")]
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }
        [Route("Contact")]
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }
    }
}