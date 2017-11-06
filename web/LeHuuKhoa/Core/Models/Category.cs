
namespace LeHuuKhoa.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Avatar { get; set; }

        public byte DisplayOrder { get; set; }

        public File File { get; set; }

        public string Descriptions { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }


        public void Modify(string name, byte displayOrder, string avatar, string descriptions, bool isDeleted, bool isPublished)
        {
            Name = name;
            DisplayOrder = displayOrder;
            Avatar = avatar;
            Descriptions = descriptions;
            IsDeleted = isDeleted;
            IsPublished = isPublished;
        }
    }
}