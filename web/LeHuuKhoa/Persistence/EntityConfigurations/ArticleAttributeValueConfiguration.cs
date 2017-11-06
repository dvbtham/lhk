using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class ArticleAttributeValueConfiguration : EntityTypeConfiguration<ArticleAttributeValue>
    {
        public ArticleAttributeValueConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}