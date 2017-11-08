using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasKey(x => x.Id);
            
            Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.Title)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.PostType)
                .IsOptional();

            Property(u => u.Slug)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Description)
                .IsOptional()
                .HasMaxLength(1000);

            Property(u => u.Content).IsOptional();

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