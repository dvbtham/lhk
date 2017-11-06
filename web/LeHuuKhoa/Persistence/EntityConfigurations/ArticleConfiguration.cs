using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
            
            Property(u => u.Title)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Slug)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Descriptions)
                .IsRequired()
                .HasMaxLength(1000);

            Property(u => u.Content).IsRequired();

            Property(u => u.CategoryId)
                .IsRequired();

            Property(u => u.DateCreated)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(u => u.DateUpdated)
                .IsOptional()
                .HasColumnType("datetime2");

        }
    }
}