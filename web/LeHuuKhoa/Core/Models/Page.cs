using System.Collections.Generic;

namespace LeHuuKhoa.Core.Models
{
    public class Page
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string BackgroundImage { get; set; }

        public string Content { get; set; }

        public bool PinToHome { get; set; }

        public ICollection<Menu> Menus { get; set; }
        
        public void Modify(string id, string name, string backgroundImage, string content)
        {
            Id = id;
            Name = name;
            BackgroundImage = backgroundImage;
            Content = content;
        }
    }
}