using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AR.Controllers
{
    public class GlassController : Controller
    {
        [Route("InfinityAR")]
        [AllowAnonymous]
        public ActionResult InfinityAR()
        {
            return View();
        }

        [Route("GoogleGlass")]
        [AllowAnonymous]
        public ActionResult GoogleGlass()
        {
            return View();
        }

        [Route("Shop")]
        [AllowAnonymous]
        public ActionResult Shop()
        {
            return View();
        }
    }
}