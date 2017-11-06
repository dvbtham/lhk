using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(x => x.Id);
            
            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Avatar)
                .IsRequired()
                .HasMaxLength(256);
            
            Property(u => u.Descriptions)
                .IsRequired();

        }
    }
}