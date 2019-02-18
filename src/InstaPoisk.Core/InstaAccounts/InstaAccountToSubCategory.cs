using InstaPoisk.References;

namespace InstaPoisk.InstaAccounts
{
    public class InstaAccountToSubCategory
    {
        public int AccountId { get; set; }

        public virtual InstaAccount Account { get; set; }

        public int CategoryId { get; set; }

        public virtual SubCategoryType Category { get; set; }
    }
}
