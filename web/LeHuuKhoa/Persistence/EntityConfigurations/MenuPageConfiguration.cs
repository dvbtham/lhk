using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class MenuPageConfiguration : EntityTypeConfiguration<MenuPage>
    {
        public MenuPageConfiguration()
        {
            HasKey(x => new { x.PageId, x.MenuId });
        }
    }
}