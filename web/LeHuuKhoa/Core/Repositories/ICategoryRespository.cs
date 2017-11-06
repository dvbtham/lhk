using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface ICategoryRespository
    {
        IEnumerable<Category> GetCategories(bool checkPublished = false);
        void Add(Category postCategory);
        Category Get(int id, bool checkPublished = false);
        void Delete(Category postCategory);
    }
}