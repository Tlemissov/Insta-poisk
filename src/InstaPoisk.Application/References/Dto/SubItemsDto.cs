using System.Collections.Generic;

namespace InstaPoisk.References.Dto
{
    public class SubItemsDto
    {
        public int Id { get; set; }

        public ReferenceEnum Type { get; set; }

        public List<int> List { get; set; }

        public SubItemsDto(int id, ReferenceEnum type, List<int> list)
        {
            Id = id;
            Type = type;
            List = list;
        }
    }
}
