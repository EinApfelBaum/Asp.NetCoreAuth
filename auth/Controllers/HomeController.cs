using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth01.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Safe()
        {
            var u = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }
    }
}
