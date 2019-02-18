using System.Threading.Tasks;
using InstaPoisk.References;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Views.Shared.Components.Menu
{
    public class MenuViewComponent : InstaPoiskViewComponent
    {
        private readonly IReferenceAppService _referenceAppService;

        public MenuViewComponent(IReferenceAppService referenceAppService)
        {
            _referenceAppService = referenceAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _referenceAppService.GetCategoryForMenu());
        }
    }
}
