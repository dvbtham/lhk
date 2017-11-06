using System;
using System.Data.Entity.Validation;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Repositories;
using LeHuuKhoa.Persistence.Repositories;

namespace LeHuuKhoa.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMenuRepository Menus { get; }
        public IPageRepository Pages { get; }
        public ICategoryRespository Categories { get; }
        public IUserRepository ApplicationUsers { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            ApplicationUsers = new UserRepository(context);
            Pages = new PageRepository(context);
            Menus = new MenuRepository(context);
        }
        public void Complete()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine(
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw;
            }
            
        }
    }
}