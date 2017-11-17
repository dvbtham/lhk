using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IPostCategoryRespository
    {
        IEnumerable<PostCategory> GetCategories();
        void Add(PostCategory postCategory);
        PostCategory Get(string id, bool include = false);
        void Delete(PostCategory postCategory);
    }
}