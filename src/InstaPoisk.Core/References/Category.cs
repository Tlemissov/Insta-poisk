using System.Collections.Generic;
using Abp.Domain.Entities;
using InstaPoisk.Common;

namespace InstaPoisk.References
{
    public class Category : Entity, IEntityName
    {
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
