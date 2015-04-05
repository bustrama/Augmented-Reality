using Microsoft.Owin.Security;
using Site.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [Route("login")]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult login(string returnUrl)
        {
            var model = new Login { ReturnUrl = returnUrl };
            return View(model);
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult login(Login model)
        {
            if (!ModelState.IsValid)
                return View();

            if (model.Email == "admin@admin.com" && model.Password == "password")
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "Ben"),
                    new Claim(ClaimTypes.Email, "A@b.com"),
                    new Claim(ClaimTypes.Country, "Israel")
                }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        public string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }
    }
}