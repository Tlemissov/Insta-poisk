namespace InstaPoisk.References
{
    public class SubCategoryToType
    {
        public int SubCategorId { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        public int TypeId { get; set; }

        public virtual SubCategoryType Type { get; set; }
    }
}
