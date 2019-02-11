using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using InstaPoisk.Authorization;
using InstaPoisk.Controllers;
using InstaPoisk.Roles;
using InstaPoisk.Roles.Dto;
using InstaPoisk.Web.Models.Roles;
using Microsoft.AspNetCore.Mvc;

namespace InstaPoisk.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Roles)]
    [Area("Admin")]
    public class RolesController : InstaPoiskControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RolesController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = (await _roleAppService.GetRolesAsync(new GetRolesInput())).Items;
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new RoleListViewModel
            {
                Roles = roles,
                Permissions = permissions
            };

            return View(model);
        }

        public async Task<ActionResult> EditRoleModal(int roleId)
        {
            var output = await _roleAppService.GetRoleForEdit(new EntityDto(roleId));
            var model = new EditRoleModalViewModel(output);

            return View("_EditRoleModal", model);
        }
    }
}
