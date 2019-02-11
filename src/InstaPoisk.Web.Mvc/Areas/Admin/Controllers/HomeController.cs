using Abp.AspNetCore.Mvc.Authorization;
using InstaPoisk.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize]
    [Area("Admin")]
    public class HomeController : InstaPoiskControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
