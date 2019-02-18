using System.Collections.Generic;
using Abp.AutoMapper;
using InstaPoisk.Common;

namespace InstaPoisk.InstaAccounts.Dto
{
    [AutoMap(typeof(InstaAccount))]
    public class InstaAccountListDto : EntityNameDto
    {
        public string UserName { get; set; }

        public string Link { get; set; }

        public string Status { get; set; }

        public bool IsPublish { get; set; }

        public string Category { get; set; }

        public List<string> SubItems { get; set; } = new List<string>();
    }
}
