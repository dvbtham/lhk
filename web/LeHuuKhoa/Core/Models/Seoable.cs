using System;

namespace LeHuuKhoa.Core.Models
{
    public class Seoable : ISeoable
    {
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }
    }
}