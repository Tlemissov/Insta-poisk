using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using InstaPoisk.Roles.Dto;
using InstaPoisk.Users.Dto;

namespace InstaPoisk.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
