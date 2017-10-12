using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class PageConfiguration : EntityTypeConfiguration<Page>
    {
        public PageConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).IsRequired().HasMaxLength(256);

            Property(x => x.Name).IsRequired().HasMaxLength(256);

            Property(x => x.BackgroundImage).IsOptional().HasMaxLength(256);

            Property(x => x.Content).IsRequired();
        }
    }
}