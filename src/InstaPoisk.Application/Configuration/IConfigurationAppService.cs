using System.Threading.Tasks;
using InstaPoisk.Configuration.Dto;

namespace InstaPoisk.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
