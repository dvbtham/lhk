using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetUsers();
        void Add(ApplicationUser user);
        void Delete(ApplicationUser user);
        ApplicationUser Get(string id);

    }
}