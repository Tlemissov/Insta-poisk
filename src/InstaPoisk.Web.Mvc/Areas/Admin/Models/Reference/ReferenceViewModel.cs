using System.Collections.Generic;
using Abp.AutoMapper;
using InstaPoisk.Common;
using InstaPoisk.References.Dto;

namespace InstaPoisk.Web.Areas.Admin.Models.Reference
{
    [AutoMap(typeof(ReferenceDto))]
    public class ReferenceViewModel : ReferenceDto
    {
        public List<EntityNameDto> Categories { get; set; } = new List<EntityNameDto>();

        public List<EntityNameDto> Types { get; set; } = new List<EntityNameDto>();
    }
}
