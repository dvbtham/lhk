using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRespository
    {
        private readonly IApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories(bool checkPublished = false)
        {
            return checkPublished ? _context.Categories.Where(x => x.IsDeleted == false && x.IsPublished).ToList() : _context.Categories.Where(x => x.IsDeleted == false).ToList();
        }

        public void Add(Category postCategory)
        {
            _context.Categories.Add(postCategory);
        }

        public Category Get(int id, bool checkPublished = false)
        {
            return checkPublished ? _context.Categories.Where(x => x.IsDeleted == false && x.IsPublished).SingleOrDefault(x => x.Id == id) : _context.Categories.Where(x => x.IsDeleted == false).SingleOrDefault(x => x.Id == id);
        }


        public void Delete(Category postCategory)
        {
            postCategory.IsDeleted = true;
        }
    }
}