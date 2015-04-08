using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class InfoController : Controller
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

        [Route("metaio")]
        [AllowAnonymous]
        public ActionResult Metaio()
        {
            return View();
        }
    }
}