using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class FileDownLoadRepository : IFileDownLoadRepository
    {
        private readonly ApplicationDbContext _context;

        public FileDownLoadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(FileDownLoad entity)
        {
            _context.FileDownLoads.Add(entity);
        }

        public FileDownLoad Get(string id)
        {
            return _context.FileDownLoads.SingleOrDefault(x => x.Id == id);
        }

        public IList<FileDownLoad> GetAll()
        {
            return _context.FileDownLoads.ToList();
        }
    }
}