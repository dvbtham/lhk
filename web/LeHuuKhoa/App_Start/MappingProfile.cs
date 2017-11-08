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
                mapper.CreateMap<PostCategory, PostCategoryViewModel>();
                mapper.CreateMap<Post, PostViewModel>();
                
                // View Model to Domain
                mapper.CreateMap<MenuViewModel, Menu>();
                mapper.CreateMap<PageViewModel, Page>()
                    .ForMember(x => x.Id, opt => opt.Ignore());
                mapper.CreateMap<PostCategoryViewModel, PostCategory>().ForMember(pc => pc.Id, opt => opt.MapFrom(x => SlugHelper.ToUnsignString(x.Name)));
                mapper.CreateMap<PostViewModel, Post>().ForMember(pc => pc.Slug, opt => opt.MapFrom(x => SlugHelper.ToUnsignString(x.Title)));

            });
        }
    }
}