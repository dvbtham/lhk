using System.Data.Entity;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<PostFile> PostFiles { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostCategory> Categories { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<Menu> Menus { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
    }
}