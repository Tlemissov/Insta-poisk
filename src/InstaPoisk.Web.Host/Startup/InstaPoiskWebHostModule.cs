using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using InstaPoisk.Configuration;

namespace InstaPoisk.Web.Host.Startup
{
    [DependsOn(
       typeof(InstaPoiskWebCoreModule))]
    public class InstaPoiskWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public InstaPoiskWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InstaPoiskWebHostModule).GetAssembly());
        }
    }
}
