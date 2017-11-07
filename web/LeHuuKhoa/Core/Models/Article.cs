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
        
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        
        public ApplicationUser Author { get; set; }

        public int Views { get; set; }

        public bool IsPopularPost { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public IList<ArticleFile> Files { get; protected set; } = new List<ArticleFile>();

        public IList<ArticleAttributeValue> AttributeValues { get; protected set; } = new List<ArticleAttributeValue>();

        public void AddFile(ArticleFile file)
        {
            file.Article = this;
            Files.Add(file);
        }

        public void RemoveFile(ArticleFile file)
        {
            file.Article = null;
            Files.Remove(file);
        }
        public void AddAttributeValue(ArticleAttributeValue attributeValue)
        {
            attributeValue.Article = this;
            AttributeValues.Add(attributeValue);
        }
    }
}