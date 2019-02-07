using System.ComponentModel.DataAnnotations;

namespace InstaPoisk.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}