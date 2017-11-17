using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;
using System.Data.Entity;

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
            var postFile = new PostFile { PostId = postId, FileId = fileId };
            _context.PostFiles.Add(postFile);
        }

        public void Add(ref PostFile postFile)
        {
            _context.PostFiles.Add(postFile);
        }

        public PostFile GetByPostId(long postId)
        {
            return _context.PostFiles.SingleOrDefault(x => x.PostId == postId);
        }

        public PostFile Get(long postId, long fileId)
        {
            return _context.PostFiles.SingleOrDefault(x => x.PostId == postId && x.FileId == fileId);
        }

        public void Delete(PostFile postFile)
        {
            _context.PostFiles.Remove(postFile);
        }

        public IList<PostFile> GetPostFiles(long postId, bool includeFile = false)
        {
            return includeFile ? _context.PostFiles.Include(x => x.File).Where(x => x.PostId == postId).ToList() : _context.PostFiles.Where(x => x.PostId == postId).ToList();
        }
    }
}