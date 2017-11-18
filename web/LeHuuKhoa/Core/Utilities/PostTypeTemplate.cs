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
                new PostTypeTemplate{ Id = (int)PostType.File, Name = "Nội dung qua tệp" },
                new PostTypeTemplate{ Id = (int)PostType.Content, Name = "Nội dung soạn online" }
            };
        }
        public IList<PostTypeTemplate> Data { get; }
    }
}