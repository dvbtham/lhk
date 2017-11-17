using System.Collections.Generic;
using System.Linq;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Persistence.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;

        public FileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(File file)
        {
            _context.Files.Add(file);
        }

        public IList<File> GetFiles()
        {
            return _context.Files.ToList();
        }
    }
}