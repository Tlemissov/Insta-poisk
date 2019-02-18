using System.Collections.Generic;
using InstaPoisk.Common;
using InstaPoisk.InstaAccounts.Dto;

namespace InstaPoisk.Web.Areas.Admin.Models.InstaAccounts
{
    public class InstaAccountViewModel 
    {
        public InstaAccountDto InstaAccount { get; set; } = new InstaAccountDto();

        public List<EntityNameDto> Categories { get; set; } = new List<EntityNameDto>();

        public List<EntityNameDto> SubCategories { get; set; } = new List<EntityNameDto>();
    }
}
