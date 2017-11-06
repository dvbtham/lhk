namespace LeHuuKhoa.Core.Models
{
    public class Category
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Avatar { get; set; }

        public byte DisplayOrder { get; set; }

        public File File { get; set; }

        public string Descriptions { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public ArticleGroup ArticleGroup { get; set; }

        public void Modify(string categoryName, byte categoryDisplayOrder, string categoryAvatar, string categoryDescriptions)
        {
           
        }
    }
}