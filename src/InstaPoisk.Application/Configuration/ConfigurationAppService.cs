using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using InstaPoisk.Configuration.Dto;

namespace InstaPoisk.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : InstaPoiskAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
