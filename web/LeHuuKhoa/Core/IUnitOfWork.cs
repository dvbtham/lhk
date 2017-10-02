using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Core
{
    public interface IUnitOfWork
    {
        IPostRespository Posts { get; }
        IPostCategoryRespository Categories { get; }
        void Complete();
    }
}