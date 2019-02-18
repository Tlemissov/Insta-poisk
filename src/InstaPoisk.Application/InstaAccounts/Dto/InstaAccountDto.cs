using System.Collections.Generic;
using Abp.AutoMapper;
using InstaPoisk.Common;

namespace InstaPoisk.InstaAccounts.Dto
{
    [AutoMap(typeof(InstaAccount))]
    public class InstaAccountDto : EntityNameDto
    {
        public string UserName { get; set; }

        public string Link { get; set; }

        public AccountStatusEnum Status { get; set; }

        public bool IsPublish { get; set; }

        public int CategoryId { get; set; }

        public virtual List<int> SubItems { get; set; } = new List<int>();
    }
}
