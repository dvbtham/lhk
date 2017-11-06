namespace LeHuuKhoa.Core.Models
{
    public class ArticleAttributeValue
    {
        public long Id { get; set; }

        public long AttributeId { get; set; }

        public virtual ArticleAttribute Attribute { get; set; }

        public long ArticleId { get; set; }

        public Article Article { get; set; }

        public string Value { get; set; }
    }
}