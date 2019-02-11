using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace InstaPoisk.Web.Areas.Admin.Views
{
    public abstract class InstaPoiskRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected InstaPoiskRazorPage()
        {
            LocalizationSourceName = InstaPoiskConsts.LocalizationSourceName;
        }
    }
}
