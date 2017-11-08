using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class PostRepository : IPostRespository
    {
        private readonly IApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetPosts(string includes = null)
        {
            if (includes != null)
                return _context.Posts.Include(includes).ToList();
            return _context.Posts.ToList();
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
        }

        public Post Get(long id)
        {
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }
    }
}