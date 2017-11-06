namespace LeHuuKhoa.Core.Models
{
    public class ArticleGroupArticleAttribute
    {
        public int ArticleGroupId { get; set; }

        public ArticleGroup ArticleGroup { get; set; }

        public long ArticleAttributeId { get; set; }

        public ArticleAttribute ArticleAttribute { get; set; }
    }
}