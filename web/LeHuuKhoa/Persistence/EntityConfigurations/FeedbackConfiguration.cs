using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class FeedbackConfiguration : EntityTypeConfiguration<Feedback>
    {
        public FeedbackConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Fullname).HasMaxLength(256).IsRequired();
            Property(x => x.Email).HasMaxLength(256).IsRequired();
            Property(x => x.Message).HasMaxLength(1500).IsRequired();

            Property(x => x.Address).HasMaxLength(500).IsOptional();
            Property(x => x.Country).HasMaxLength(500).IsOptional();
            Property(x => x.Website).HasMaxLength(500).IsOptional();
            Property(x => x.Phone).HasMaxLength(100).IsOptional();
        }
    }
}