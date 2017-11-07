using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;
using System.Data.Entity;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IApplicationDbContext _context;

        public ArticleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ArticleGroup> GetArticleGroups()
        {
            return _context.ArticleGroups.Include(x => x.ArticleAttributes).ToList();
        }

        public IList<ArticleAttribute> GetAttributes(int groupId)
        {
            return _context.ArticleGroupArticleAttributes.Where(x => x.ArticleGroupId == groupId).Select(x => x.ArticleAttribute).ToList();
        }

        public IEnumerable<Article> GetAll(bool checkPublished = false)
        {
            var query = _context.Articles.Include(x => x.Category).Where(x => x.IsDeleted == false);
            if (checkPublished)
                query = query.Where(x => x.IsPublished);
            return query;
        }

        public Article Get(long id, bool checkPublished = false)
        {

            return checkPublished
                ? _context.Articles.SingleOrDefault(x => x.Id == id && x.IsPublished && x.IsDeleted == false)
                : _context.Articles.SingleOrDefault(x => x.Id == id && x.IsDeleted == false);
        }

        public void Delete(Article entity)
        {
            entity.IsDeleted = true;
        }

        public void Add(Article entity)
        {
            _context.Articles.Add(entity);
        }
    }
}