using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IPostFileRepository
    {
        void Add(long postId, long fileId);
        void Add(ref PostFile postFile);
        PostFile GetByPostId(long postId);
        PostFile Get(long postId, long fileId);
        void Delete(PostFile postFile);
        IList<PostFile> GetPostFiles(long postId, bool includeFile = false);
    }
}
