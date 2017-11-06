using AutoMapper;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;
using LeHuuKhoa.Core.ViewModels;

namespace LeHuuKhoa
{
    public class MappingProfile : Profile
    {
        public static void MappingConfig()
        {
            Mapper.Initialize(mapper =>
            {
                //Domain to view Model
                mapper.CreateMap<Menu, MenuViewModel>();
                mapper.CreateMap<Page, PageViewModel>();
                mapper.CreateMap<Category, CategoryViewModel>();
                // View Model to Domain
                mapper.CreateMap<MenuViewModel, Menu>();
                mapper.CreateMap<CategoryViewModel, Category>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(pc => pc.Slug, opt => opt.MapFrom(x => SlugHelper.ToUnsignString(x.Name)));

            });
        }
    }
}