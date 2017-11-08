namespace LeHuuKhoa.Core.Models
{
    public class Menu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PageId { get; set; }

        public Page Page { get; set; }

        
        public void Modify(string name, string pageId)
        {
            Name = name;
            PageId = pageId;
        }
    }
}