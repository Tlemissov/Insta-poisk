using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaPoisk.References;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Views.Shared.Components.SideMenu
{
    public class SideMenuViewComponent : InstaPoiskViewComponent
    {
        private readonly IReferenceAppService _referenceAppService;

        public SideMenuViewComponent(IReferenceAppService referenceAppService)
        {
            _referenceAppService = referenceAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, int? subCategoryId)
        {
            ViewBag.CategoryId = categoryId;
            ViewBag.SubCategoryId = subCategoryId;
            return View(await _referenceAppService.GetSubCategoryType(categoryId));
        }
    }
}
