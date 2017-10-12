using System;
using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void Add(ApplicationUser user)
        {
            try
            {
                _context.Users.Add(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(ApplicationUser user)
        {
            try
            {
                _context.Users.Remove(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ApplicationUser Get(string id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            return user;
        }
    }
}