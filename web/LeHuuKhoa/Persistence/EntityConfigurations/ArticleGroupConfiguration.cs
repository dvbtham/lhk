using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class ArticleGroupConfiguration : EntityTypeConfiguration<ArticleGroup>
    {
        public ArticleGroupConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).IsRequired().HasMaxLength(256);
        }
        
    }
}