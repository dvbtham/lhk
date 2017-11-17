using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class PostCategoryConfiguration : EntityTypeConfiguration<PostCategory>
    {
        public PostCategoryConfiguration()
        {
            HasKey(x => x.Id);
            
            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.ImageUrl)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.BackgroundImage)
                .IsRequired()
                .HasMaxLength(256);

            Property(p => p.ShortDescriptions).IsOptional();

            Property(u => u.Descriptions)
                .IsRequired();

        }
    }
}