using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Utilities
{
    public class PostTypeTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PostTypeData
    {
        public PostTypeData()
        {
            Data = new List<PostTypeTemplate>
            {
                new PostTypeTemplate{ Id = (int)PostType.Pdf, Name = "Nội dung qua tệp (.pdf)" },
                new PostTypeTemplate{ Id = (int)PostType.PowerPoint, Name = "Hình ảnh" },
                new PostTypeTemplate{ Id = (int)PostType.Content, Name = "Nội dung soạn online" }
            };
        }
        public IList<PostTypeTemplate> Data { get; }
    }
}