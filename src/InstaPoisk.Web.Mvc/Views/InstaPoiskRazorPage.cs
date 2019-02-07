using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace InstaPoisk.Web.Views
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
