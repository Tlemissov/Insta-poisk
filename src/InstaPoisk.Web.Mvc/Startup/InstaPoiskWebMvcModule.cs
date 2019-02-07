using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using InstaPoisk.Configuration;

namespace InstaPoisk.Web.Startup
{
    [DependsOn(typeof(InstaPoiskWebCoreModule))]
    public class InstaPoiskWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public InstaPoiskWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<InstaPoiskNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InstaPoiskWebMvcModule).GetAssembly());
        }
    }
}
