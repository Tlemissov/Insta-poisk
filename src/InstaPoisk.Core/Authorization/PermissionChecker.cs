using Abp.Authorization;
using InstaPoisk.Authorization.Roles;
using InstaPoisk.Authorization.Users;

namespace InstaPoisk.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
