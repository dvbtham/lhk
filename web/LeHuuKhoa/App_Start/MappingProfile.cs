using System.Linq;
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
                mapper.CreateMap<Menu, MenuViewModel>()
                    .ForMember(mv => mv.Id, opt => opt.Ignore())
                    .ForMember(mv => mv.Name, opt => opt.MapFrom(m => m.Name))
                    .ForMember(mv => mv.Pages, opt => opt.MapFrom(m => m.MenuPages.Select(mv => mv.PageId)));
                
                // View Model to Domain
                mapper.CreateMap<MenuViewModel, Menu>()
                    .ForMember(m => m.Id, opt => opt.Ignore())
                    .ForMember(m => m.Name, opt => opt.MapFrom(mv => mv.Name))
                    .ForMember(m => m.MenuPages, opt => opt.Ignore())
                    .AfterMap((mv, m) =>
                    {
                        //Remove unselected pages
                        var removedPages = m.MenuPages.Where(p => !mv.Pages.Contains(p.PageId)).ToList();
                        foreach (var f in removedPages)
                            m.MenuPages.Remove(f);

                        // Add new pages
                        var addedPages = mv.Pages
                            .Where(id => m.MenuPages.All(x => x.PageId != id))
                            .Select(id => new MenuPage { PageId = id }).ToList();

                        foreach (var f in addedPages)
                            m.MenuPages.Add(f);
                    });
                
            });
        }
    }
}