using System.Collections.Generic;

namespace LeHuuKhoa.Core.Models
{
    public class Article : Seoable
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Descriptions { get; set; }

        public string BackgroundImage { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        
        public ApplicationUser Author { get; set; }

        public int Views { get; set; }

        public bool IsPopularPost { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public IList<ArticleAttributeValue> AttributeValues { get; protected set; } = new List<ArticleAttributeValue>();

    }
}