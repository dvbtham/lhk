﻿using System.Data.Entity.ModelConfiguration;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Persistence.EntityConfigurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(x => x.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Avatar)
                .IsRequired()
                .HasMaxLength(256);
            
            Property(u => u.Descriptions)
                .IsRequired();

        }
    }
}