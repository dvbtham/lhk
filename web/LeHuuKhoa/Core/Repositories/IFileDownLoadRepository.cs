using System.Collections.Generic;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.Repositories
{
    public interface IFileDownLoadRepository
    {
        void Add(FileDownLoad entity);
        FileDownLoad Get(string id);
        IList<FileDownLoad> GetAll();
    }
}
