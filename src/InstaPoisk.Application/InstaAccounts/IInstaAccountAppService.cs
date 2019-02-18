using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using InstaPoisk.InstaAccounts.Dto;

namespace InstaPoisk.InstaAccounts
{
    public interface IInstaAccountAppService : IApplicationService
    {
        Task<List<InstaAccountListDto>> GetForTable();

        Task<List<InstaAccountShortListDto>> GetList(InstaAccountInput input);

        Task<InstaAccountDto> Get(int id);

        Task Create(InstaAccountDto input);

        Task Delete(int id);

        Task Update(InstaAccountDto input);
    }
}
