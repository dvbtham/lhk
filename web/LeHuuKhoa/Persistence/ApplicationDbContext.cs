using System.Data.Entity;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeHuuKhoa.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<ArticleAttribute> ArticleAttributes { get; set; }
        public DbSet<ArticleAttributeValue> ArticleAttributeValues { get; set; }
        public DbSet<ArticleFile> ArticleFiles { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ArticleGroupArticleAttribute> ArticleGroupArticleAttributes { get; set; }

        public override IDbSet<ApplicationUser> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new ArticleAttributeValueConfiguration());
            modelBuilder.Configurations.Add(new ArticleFileConfiguration());
            modelBuilder.Configurations.Add(new PageConfiguration());
            modelBuilder.Configurations.Add(new FileConfiguration());
            modelBuilder.Configurations.Add(new ArticleGroupConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ArticleGroupArticleAttributeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}