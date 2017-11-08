namespace LeHuuKhoa.Core.Models
{
    public class PostCategory
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public byte DisplayOrder { get; set; }

        public string ImageUrl { get; set; }

        public string BackgroundImage { get; set; }

        public string ShortDescriptions { get; set; }

        public string Descriptions { get; set; }

        public void Modify(string name, byte displayOrder, string imageUrl, string backgroundImage, string shortDescriptions, string descriptions)
        {
            Name = name;
            DisplayOrder = displayOrder;
            ImageUrl = imageUrl;
            BackgroundImage = backgroundImage;
            ShortDescriptions = shortDescriptions;
            Descriptions = descriptions;
        }
    }
}