namespace LeHuuKhoa.Areas.Administrations.Models
{
    public class UserNavbarViewModel
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public AdminZone Zone { get; set; }
    }

    /// <summary>
    /// Sidebar = 10,
    /// TopNavbar = 20
    /// </summary>
    public enum AdminZone
    {
        Sidebar = 10,
        TopNavbar = 20
    }
}