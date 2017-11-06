using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            HasKey(x => x.Id);

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
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.DateCreated)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(u => u.DateUpdated)
                .IsOptional()
                .HasColumnType("datetime2");

        }
    }
}