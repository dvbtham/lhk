using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IApplicationDbContext _context;

        public MenuRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Menu> GetMenus()
        {
            return _context.Menus.ToList();
        }

        public IEnumerable<Menu> GetMenusRelated()
        {
            return _context.Menus.Include(x => x.MenuPages.Select(p => p.Page));
        }

        public Menu Get(int id)
        {
            return _context.Menus.SingleOrDefault(x => x.Id == id);
        }

        public Menu GetRelated(int id)
        {
            return _context.Menus.Include(x => x.MenuPages).SingleOrDefault(x => x.Id == id);
        }

        public void Delete(Menu menu)
        {
            _context.Menus.Remove(menu);
        }

        public void Add(Menu menu)
        {
            _context.Menus.Add(menu);
        }
    }
}