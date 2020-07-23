using Microsoft.AspNetCore.Mvc;

namespace Soulgram.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel({ReturnUrl = reu}));
        }

        public IActionResult Login(LoginViewModel model)
        {
            return View();
        }
    }
}
