using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using InstaPoisk.Authorization;
using InstaPoisk.Controllers;
using InstaPoisk.MultiTenancy;
using InstaPoisk.MultiTenancy.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    [Area("Admin")]
    public class TenantsController : InstaPoiskControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _tenantAppService.GetAll(new PagedTenantResultRequestDto { MaxResultCount = int.MaxValue }); // Paging not implemented yet
            return View(output);
        }

        public async Task<ActionResult> EditTenantModal(int tenantId)
        {
            var tenantDto = await _tenantAppService.Get(new EntityDto(tenantId));
            return View("_EditTenantModal", tenantDto);
        }
    }
}
