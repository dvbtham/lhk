using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IPostCategoryRespository
    {
        IEnumerable<Category> GetCategories();
        void Add(Category postCategory);
        Category Get(string id);
        void Delete(Category postCategory);
    }
}