using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IFileRepository
    {
        void Add(File file);

        IList<File> GetFiles();
    }
}
