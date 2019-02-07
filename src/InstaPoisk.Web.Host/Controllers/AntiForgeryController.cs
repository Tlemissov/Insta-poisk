using Microsoft.AspNetCore.Antiforgery;
using InstaPoisk.Controllers;

namespace InstaPoisk.Web.Host.Controllers
{
    public class AntiForgeryController : InstaPoiskControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
