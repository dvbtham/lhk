namespace LeHuuKhoa.Core.Models
{
    public class MenuPage
    {
        public int MenuId { get; set; }

        public Menu Menu { get; set; }
        
        public string PageId { get; set; }

        public Page Page { get; set; }

    }
}