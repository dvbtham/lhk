using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class ArticleGroupArticleAttributeConfiguration : EntityTypeConfiguration<ArticleGroupArticleAttribute>
    {
        public ArticleGroupArticleAttributeConfiguration()
        {
            HasKey(k => new { k.ArticleAttributeId, k.ArticleGroupId });
            HasRequired(x => x.ArticleGroup).WithMany(x => x.ArticleAttributes)
                .HasForeignKey(x => x.ArticleGroupId);

            HasRequired(x => x.ArticleAttribute).WithMany(x => x.ArticleGroups)
                .HasForeignKey(x => x.ArticleAttributeId);
        }
    }
}