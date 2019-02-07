using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace InstaPoisk.Controllers
{
    public abstract class InstaPoiskControllerBase: AbpController
    {
        protected InstaPoiskControllerBase()
        {
            LocalizationSourceName = InstaPoiskConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
