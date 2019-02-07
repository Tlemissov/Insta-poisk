using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using InstaPoisk.Controllers;

namespace InstaPoisk.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : InstaPoiskControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
