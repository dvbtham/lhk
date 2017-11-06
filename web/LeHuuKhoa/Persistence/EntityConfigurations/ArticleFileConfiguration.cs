using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class ArticleFileConfiguration : EntityTypeConfiguration<ArticleFile>
    {
        public ArticleFileConfiguration()
        {
            HasKey(x => new {x.ArticleId, x.FileId});
        }
    }
}