using AutoMapper;
using LeHuuKhoa.Core.Models;
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
                // View Model to Domain
                mapper.CreateMap<MenuViewModel, Menu>();

            });
        }
    }
}