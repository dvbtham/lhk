using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LeHuuKhoa.Core.Models
{
    public class FileDownLoad
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int FileSize { get; set; }

        public FileType FileType { get; set; }

        public string Caption { get; set; }
        
        public ICollection<Post> Posts { get; set; }

        public FileDownLoad()
        {
            Posts = new Collection<Post>();
        }
        
    }
}