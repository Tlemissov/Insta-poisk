using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;
using InstaPoisk.Common;

namespace InstaPoisk.References
{
    public class Category : Entity, IEntityName
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
