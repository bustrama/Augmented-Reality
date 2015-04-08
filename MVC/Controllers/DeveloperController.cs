using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AR.Controllers
{
    public class DeveloperController : Controller
    {
        [Route("metaio")]
        [AllowAnonymous]
        public ActionResult Metaio()
        {
            return View();
        }
    }
}