using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LeHuuKhoa.Core.Models
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public ICollection<MenuPage> MenuPages { get; set; }

        public Menu()
        {
            MenuPages = new Collection<MenuPage>();
        }

        public void Modify(string name)
        {
            Name = name;
        }
    }
}