using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class FileDownLoadConfiguration : EntityTypeConfiguration<FileDownLoad>
    {
        public FileDownLoadConfiguration()
        {
            HasKey(x => x.Id);
            
            Property(x => x.Caption).HasMaxLength(700).IsOptional();
            
        }
    }
}