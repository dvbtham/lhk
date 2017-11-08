using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly IApplicationDbContext _context;

        public PageRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Page> GetPages()
        {
            return _context.Pages.ToList();
        }

        public Page Get(string id)
        {
            return _context.Pages.SingleOrDefault(x => x.Id == id);
        }

        public Page GetForHomePage()
        {
            return _context.Pages.SingleOrDefault(x => x.PinToHome);
        }

        public void Delete(Page page)
        {
            _context.Pages.Remove(page);
        }

        public void Add(Page page)
        {
            _context.Pages.Add(page);
        }
    }
}