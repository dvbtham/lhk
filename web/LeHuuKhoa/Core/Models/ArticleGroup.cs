using System.Collections.Generic;

namespace LeHuuKhoa.Core.Models
{
    public class ArticleGroup
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public IList<ArticleGroupArticleAttribute> ArticleAttributes { get; set; } = new List<ArticleGroupArticleAttribute>();
        public void AddAttribute(long attributeId)
        {
            var articleGroupAttribute = new ArticleGroupArticleAttribute
            {
                ArticleGroup = this,
                ArticleAttributeId = attributeId
            };
            ArticleAttributes.Add(articleGroupAttribute);
        }
    }
}