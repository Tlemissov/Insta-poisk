using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using InstaPoisk.Common;
using InstaPoisk.References.Dto;

namespace InstaPoisk.References
{
    public interface IReferenceAppService : IApplicationService
    {
        Task<List<ReferenceListDto>> GetForTable(ReferenceEnum type);

        Task<List<EntityNameDto>> GetList(ReferenceEnum type);

        Task<ReferenceDto> Get(int id, ReferenceEnum type);

        Task Create(ReferenceDto input);

        Task Delete(int id, ReferenceEnum type);

        Task Update(ReferenceDto input);

        Task<List<MenuCategoryDto>> GetCategoryForMenu();

        Task<List<EntityNameDto>> GetSubCategoryType(int subCategoryId);
    }
}
