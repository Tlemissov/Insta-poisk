using Abp.Application.Services;
using Abp.Application.Services.Dto;
using InstaPoisk.MultiTenancy.Dto;

namespace InstaPoisk.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

