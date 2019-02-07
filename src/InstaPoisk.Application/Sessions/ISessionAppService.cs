using System.Threading.Tasks;
using Abp.Application.Services;
using InstaPoisk.Sessions.Dto;

namespace InstaPoisk.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
