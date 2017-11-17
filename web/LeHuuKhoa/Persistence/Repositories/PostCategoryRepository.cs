using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;
using System.Data.Entity;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class PostCategoryRepository : IPostCategoryRespository
    {
        private readonly IApplicationDbContext _context;

        public PostCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<PostCategory> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void Add(PostCategory postCategory)
        {
            _context.Categories.Add(postCategory);
        }

        public PostCategory Get(string id, bool include = false)
        {
            return include ? _context.Categories.Include(x => x.Posts).SingleOrDefault(x => x.Id == id) : _context.Categories.SingleOrDefault(x => x.Id == id);
        }


        public void Delete(PostCategory postCategory)
        {
            _context.Categories.Remove(postCategory);
        }
    }
}