using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class PostCategoryRepository : IPostCategoryRespository
    {
        private readonly IApplicationDbContext _context;

        public PostCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void Add(Category postCategory)
        {
            _context.Categories.Add(postCategory);
        }

        public Category Get(string id)
        {
            return _context.Categories.SingleOrDefault(x => x.Id == id);
        }


        public void Delete(Category postCategory)
        {
            _context.Categories.Remove(postCategory);
        }
    }
}