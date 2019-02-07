using Abp.Application.Services.Dto;

namespace InstaPoisk.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

