using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using InstaPoisk.Common;
using InstaPoisk.References;

namespace InstaPoisk.InstaAccounts
{
    public class InstaAccount : FullAuditedEntity, ILink, IPublish
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(64)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Link { get; set; }

        public int LinkOpened { get; set; }

        public AccountStatusEnum Status { get; set; }

        public bool IsPublish { get; set; }

        public DateTime? PublishDate { get; set; }

        public int CategoryId { get; set; }

        public virtual SubCategory Category { get; set; }

        public virtual ICollection<InstaAccountToSubCategory> SubCategories { get; set; } = new List<InstaAccountToSubCategory>();
    }
}
