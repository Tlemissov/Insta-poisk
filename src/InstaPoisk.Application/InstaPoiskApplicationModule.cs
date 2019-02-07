using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using InstaPoisk.Authorization;

namespace InstaPoisk
{
    [DependsOn(
        typeof(InstaPoiskCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class InstaPoiskApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<InstaPoiskAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(InstaPoiskApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
