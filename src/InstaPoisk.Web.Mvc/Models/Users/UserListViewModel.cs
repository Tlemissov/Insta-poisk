using System.Collections.Generic;
using InstaPoisk.Roles.Dto;
using InstaPoisk.Users.Dto;

namespace InstaPoisk.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
