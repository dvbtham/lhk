using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetMenus();
        Menu Get(int id);
        void Delete(Menu menu);
        void Add(Menu menu);
    }
}
