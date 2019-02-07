using System.Collections.Generic;
using InstaPoisk.Roles.Dto;

namespace InstaPoisk.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}