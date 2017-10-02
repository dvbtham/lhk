using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration: EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.ImageUrl)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.Birthday).IsRequired();

            Property(u => u.Gender)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}