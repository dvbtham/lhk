using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class MenuConfiguration : EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            Property(x => x.Name).IsRequired().HasMaxLength(255);

            HasRequired(x => x.Page)
                .WithMany(x => x.Menus)
                .HasForeignKey(x => x.PageId);
        }
    }
}