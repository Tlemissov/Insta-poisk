using InstaPoisk.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Controllers
{
    public class HomeController : InstaPoiskControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}