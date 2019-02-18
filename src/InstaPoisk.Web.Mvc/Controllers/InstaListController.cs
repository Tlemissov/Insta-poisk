using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaPoisk.Controllers;
using InstaPoisk.InstaAccounts;
using InstaPoisk.InstaAccounts.Dto;
using InstaPoisk.References;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Mvc.Controllers
{
    public class InstaListController : InstaPoiskControllerBase
    {
        private readonly IInstaAccountAppService _instaAccountAppService;
        private readonly IReferenceAppService _referenceAppService;

        public InstaListController(IInstaAccountAppService instaAccountAppService,
            IReferenceAppService referenceAppService)
        {
            _instaAccountAppService = instaAccountAppService;
            _referenceAppService = referenceAppService;
        }
        
        public async Task<IActionResult> Index(int? categoryId, int? subcategoryId)
        {
            var model = new List<InstaAccountShortListDto>();
            ViewBag.CategoryId = categoryId;
            ViewBag.SubCategoryId = subcategoryId;
            if (categoryId.HasValue)
            {
                model = await _instaAccountAppService.GetList(new InstaAccountInput {CategoryId = categoryId, SubCategoryId = subcategoryId});
            }
            return View(model);
        }
    }
}