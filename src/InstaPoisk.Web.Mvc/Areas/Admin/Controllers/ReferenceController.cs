using System.Threading.Tasks;
using InstaPoisk.Controllers;
using InstaPoisk.References;
using InstaPoisk.References.Dto;
using InstaPoisk.Web.Areas.Admin.Models.Reference;
using InstaPoisk.Web.Startup;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReferenceController : InstaPoiskControllerBase
    {
        private readonly IReferenceAppService _referenceAppService;

        public ReferenceController(IReferenceAppService referenceAppService)
        {
            _referenceAppService = referenceAppService;
        }

        public async Task<IActionResult> Menu()
        {
            ViewBag.Type = (int)ReferenceEnum.Category;
            ViewBag.Page = PageNames.Menu;
            ViewBag.Name = "Меню";
            return View("Index", await _referenceAppService.GetForTable(ReferenceEnum.Category));
        }

        public async Task<IActionResult> Section()
        {
            ViewBag.Type = (int)ReferenceEnum.SubCategory;
            ViewBag.Page = PageNames.Section;
            ViewBag.Name = "Разделы меню";
            return View("Index", await _referenceAppService.GetForTable(ReferenceEnum.SubCategory));
        }

        public async Task<IActionResult> SectionType()
        {
            ViewBag.Type = (int)ReferenceEnum.SubCategoryType;
            ViewBag.Page = PageNames.SectionType;
            ViewBag.Name = "Типы разделов меню";
            return View("Index", await _referenceAppService.GetForTable(ReferenceEnum.SubCategoryType));
        }

        public async Task<IActionResult> CreateOrEditCategory(ReferenceEnum type, int? id)
        {
            var model = new ReferenceViewModel();
            if (id.HasValue)
            {
                model = ObjectMapper.Map<ReferenceViewModel>(await _referenceAppService.Get((int)id, type));
            }
            model.Type = type;
            if (type == ReferenceEnum.SubCategory)
            {
                model.Categories = await _referenceAppService.GetList(ReferenceEnum.Category);
                model.Types = await _referenceAppService.GetList(ReferenceEnum.SubCategoryType);
            }
            else if (type == ReferenceEnum.SubCategoryType)
            {
                model.Types = await _referenceAppService.GetList(ReferenceEnum.SubCategory);
            }
            return PartialView("_CreateOrEditCategoryModal", model);
        }
    }
}