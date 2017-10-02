using System;

namespace LeHuuKhoa.Core.Models
{
    public class Post
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Descriptions { get; set; }

        public string Content { get; set; }

        public string CategoryId { get; set; }

        public PostCategory Category { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public string AuthorName { get; set; }

        public int Views { get; set; }

        public bool IsPopularPost { get; set; }

        public void Modify(string title, string description, string content,
            string categoryId, string metaDes, string metaKey, bool isPopular)
        {
            Title = title;
            Descriptions = description;
            Content = content;
            CategoryId = categoryId;
            MetaDescription = metaDes;
            MetaKeyword = metaKey;
            IsPopularPost = isPopular;
        }

    }
}