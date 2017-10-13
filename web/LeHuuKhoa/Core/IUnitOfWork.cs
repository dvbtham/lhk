using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Core
{
    public interface IUnitOfWork
    {
        IPostRespository Posts { get; }
        IMenuRepository Menus { get; }
        IPageRepository Pages { get; }
        IPostCategoryRespository Categories { get; }
        IUserRepository ApplicationUsers { get; }
        void Complete();
    }
}