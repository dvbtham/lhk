using LeHuuKhoa.Core.Repositories;

namespace LeHuuKhoa.Core
{
    public interface IUnitOfWork
    {
        IArticleRepository Articles { get; set; }
        IMenuRepository Menus { get; }
        IPageRepository Pages { get; }
        ICategoryRespository Categories { get; }
        IUserRepository ApplicationUsers { get; }
        void Complete();
    }
}