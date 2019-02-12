using System.Collections.Generic;
using InstaPoisk.Common;

namespace InstaPoisk.References.Dto
{
    public class ReferenceListDto : EntityNameDto
    {
        public string Section { get; set; }

        public ReferenceEnum Type { get; set; }

        public List<EntityNameDto> SubItems { get; set; }

        public ReferenceListDto(int id, string name, ReferenceEnum type, string section, List<EntityNameDto> subItems)
        {
            Id = id;
            Name = name;
            Type = type;
            Section = section;
            SubItems = subItems ?? new List<EntityNameDto>();
        }
    }
}
