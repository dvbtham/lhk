using System.Collections.Generic;

namespace LeHuuKhoa.Core.Models
{
    public class ArticleAttribute
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual IList<ArticleGroupArticleAttribute> ArticleGroups { get; protected set; } = new List<ArticleGroupArticleAttribute>();
    }
}