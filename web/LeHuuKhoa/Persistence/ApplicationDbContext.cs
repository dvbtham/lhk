using System.Data.Entity;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Persistence.EntityConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeHuuKhoa.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<PostFile> PostFiles { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public override IDbSet<ApplicationUser> Users { get; set; }

        public DbSet<PostCategory> Categories { get; set; }

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
            modelBuilder.Entity<PostFile>()
                .HasKey(x => new {x.PostId, x.FileId});

            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new FileConfiguration());
            modelBuilder.Configurations.Add(new PageConfiguration());
            modelBuilder.Configurations.Add(new PostCategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}