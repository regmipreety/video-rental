using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApplication.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OauthController : Controller
    {
        public IActionResult Login(string returnUrl = "/")
        {
            // Challenge the authentication scheme (e.g., Google)
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, "Google");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
