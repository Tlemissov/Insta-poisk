using Abp.AspNetCore.Mvc.ViewComponents;

namespace InstaPoisk.Web.Views
{
    public abstract class InstaPoiskViewComponent : AbpViewComponent
    {
        protected InstaPoiskViewComponent()
        {
            LocalizationSourceName = InstaPoiskConsts.LocalizationSourceName;
        }
    }
}
