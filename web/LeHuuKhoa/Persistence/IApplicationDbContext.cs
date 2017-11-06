using System.Data.Entity;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<Menu> Menus { get; set; }

        DbSet<ArticleAttribute> ArticleAttributes { get; set; }
        DbSet<ArticleAttributeValue> ArticleAttributeValues { get; set; }
        DbSet<ArticleFile> ArticleFiles { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<ArticleGroupArticleAttribute> ArticleGroupArticleAttributes { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
    }
}