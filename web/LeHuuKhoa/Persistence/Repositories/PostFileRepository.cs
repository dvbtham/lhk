using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class PostFileRepository : IPostFileRepository
    {
        private readonly ApplicationDbContext _context;

        public PostFileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(long postId, long fileId)
        {
            var postFile = new PostFile {PostId = postId, FileId = fileId};
            _context.PostFiles.Add(postFile);
        }
    }
}