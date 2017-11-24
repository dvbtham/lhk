using System;
using System.Data.Entity.Validation;
using LeHuuKhoa.Core;
using LeHuuKhoa.Core.Repositories;
using LeHuuKhoa.Persistence.Repositories;

namespace LeHuuKhoa.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFileRepository Files { get; set; }
        public IPostFileRepository PostFiles { get; set; }
        public IFileDownLoadRepository FileDownLoads { get; set; }
        public IPostRespository Posts { get; }
        public IMenuRepository Menus { get; }
        public IPageRepository Pages { get; }
        public IPostCategoryRespository Categories { get; }
        public IUserRepository ApplicationUsers { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Posts= new PostRepository(context);
            Categories = new PostCategoryRepository(context);
            ApplicationUsers = new UserRepository(context);
            Pages = new PageRepository(context);
            Menus = new MenuRepository(context);
            PostFiles = new PostFileRepository(context);
            Files = new FileRepository(context);
            FileDownLoads = new FileDownLoadRepository(context);
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