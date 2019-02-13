using System.Collections.Generic;
using Abp.AutoMapper;
using InstaPoisk.Common;

namespace InstaPoisk.References.Dto
{
    [AutoMap(typeof(Category))]
    public class MenuCategoryDto : EntityNameDto
    {
        public List<EntityNameDto> SubCategories { get; set; } = new List<EntityNameDto>();
    }
}
