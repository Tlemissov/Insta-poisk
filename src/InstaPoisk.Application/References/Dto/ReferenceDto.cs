using System.Collections.Generic;
using InstaPoisk.Common;

namespace InstaPoisk.References.Dto
{
    public class ReferenceDto : EntityNameDto
    {
        public ReferenceEnum Type { get; set; }

        public int? CategoryId { get; set; }

        public List<int> List { get; set; } = new List<int>();
    }
}
