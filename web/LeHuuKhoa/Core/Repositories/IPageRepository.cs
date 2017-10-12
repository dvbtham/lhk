using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetPages();
        Page Get(string id);
        void Delete(Page page);
        void Add(Page page);
    }
}