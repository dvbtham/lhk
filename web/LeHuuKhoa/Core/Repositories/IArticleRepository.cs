using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IArticleRepository
    {
        IList<ArticleGroup> GetArticleGroups();
        IList<ArticleAttribute> GetAttributes(int groupId);
        IEnumerable<Article> GetAll(bool checkPublished = false);
        Article Get(long id, bool checkPublished = false);
        void Delete(Article entity);
        void Add(Article entity);
    }
}