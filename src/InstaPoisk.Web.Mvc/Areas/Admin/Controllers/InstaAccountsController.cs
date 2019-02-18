using System.Threading.Tasks;
using InstaPoisk.Controllers;
using InstaPoisk.InstaAccounts;
using InstaPoisk.References;
using InstaPoisk.References.Dto;
using InstaPoisk.Web.Areas.Admin.Models.InstaAccounts;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstaAccountsController : InstaPoiskControllerBase
    {
        private readonly IInstaAccountAppService _accountAppService;
        private readonly IReferenceAppService _referenceAppService;

        public InstaAccountsController(IInstaAccountAppService accountAppService,
            IReferenceAppService referenceAppService)
        {
            _accountAppService = accountAppService;
            _referenceAppService = referenceAppService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _accountAppService.GetForTable());
        }

        public async Task<IActionResult> CreateOrEdit(int? id)
        {
            var model = new InstaAccountViewModel
            {
                Categories = await _referenceAppService.GetList(ReferenceEnum.SubCategory),
                SubCategories = await _referenceAppService.GetList(ReferenceEnum.SubCategoryType)
            };
            if (id.HasValue)
            {
                model.InstaAccount = await _accountAppService.Get((int) id);
            }
            return PartialView(model);
        }
    }
}