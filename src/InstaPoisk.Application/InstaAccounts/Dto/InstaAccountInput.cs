
namespace InstaPoisk.InstaAccounts.Dto
{
    public class InstaAccountInput
    {
        public string Name { get; set; }

        public int? CategoryId { get; set; }

        public int? SubCategoryId { get; set; }

        public AccountStatusEnum Status { get; set; }
    }
}
