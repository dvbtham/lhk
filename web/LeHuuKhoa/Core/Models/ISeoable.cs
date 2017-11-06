using System;

namespace LeHuuKhoa.Core.Models
{
    public interface ISeoable
    {
        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }

        string MetaKeyword { get; set; }

        string MetaDescription { get; set; }
    }
}
