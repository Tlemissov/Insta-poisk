using System.Threading.Tasks;
using Abp.Application.Services;
using InstaPoisk.Authorization.Accounts.Dto;

namespace InstaPoisk.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
