using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Core
{
    public interface IUnitOfWork
    {
        IFileRepository Files { get; set; }
        IPostFileRepository PostFiles { get; set; }
        IPostRespository Posts { get; }
        IMenuRepository Menus { get; }
        IPageRepository Pages { get; }
        IPostCategoryRespository Categories { get; }
        IUserRepository ApplicationUsers { get; }
        void Complete();
    }
}