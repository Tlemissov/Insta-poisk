using System.Collections.Generic;
using Abp.Domain.Entities;
using InstaPoisk.Common;

namespace InstaPoisk.References
{
    public class SubCategoryType : Entity, IEntityName
    {
        public string Name { get; set; }

        public virtual ICollection<SubCategoryToType> SubCategoryToTypes { get; set; } = new List<SubCategoryToType>();
    }
}
