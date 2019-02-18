using Abp.AutoMapper;
using InstaPoisk.Common;

namespace InstaPoisk.InstaAccounts.Dto
{
    [AutoMap(typeof(InstaAccount))]
    public class InstaAccountShortListDto : EntityNameDto
    {
        public string Link { get; set; }

        public AccountStatusEnum Status { get; set; }
    }
}
