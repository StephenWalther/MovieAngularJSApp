using Microsoft.AspNet.Mvc;
using System.Security.Claims;

namespace MovieAngularJSApp.Controllers
{
	[Authorize]
	public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
			var user = (ClaimsIdentity)User.Identity;
			ViewBag.Name = user.Name;
			ViewBag.CanEdit = user.FindFirst("CanEdit") != null ? "true" : "false";
			return View();
        }
    }
}
