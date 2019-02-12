using System.Collections.Generic;
using Abp.Domain.Entities;
using InstaPoisk.Common;

namespace InstaPoisk.References
{
    public class SubCategory : Entity, IEntityName
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<SubCategoryToType> SubCategoryToTypes { get; set; } = new List<SubCategoryToType>();
    }
}
