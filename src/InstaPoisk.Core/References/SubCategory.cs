using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;
using InstaPoisk.Common;
using InstaPoisk.InstaAccounts;

namespace InstaPoisk.References
{
    public class SubCategory : Entity, IEntityName
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<SubCategoryToType> SubCategoryToTypes { get; set; } = new List<SubCategoryToType>();

        public virtual ICollection<InstaAccount> InstaAccounts { get; set; } = new List<InstaAccount>();
    }
}
