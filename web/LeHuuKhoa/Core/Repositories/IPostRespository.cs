using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IPostRespository
    {
        IEnumerable<Post> GetPosts(string includes = null);

        IEnumerable<Post> GetAllWithRelated();

        void Add(Post post);

        void Delete(Post post);

        Post Get(long id);
    }
}