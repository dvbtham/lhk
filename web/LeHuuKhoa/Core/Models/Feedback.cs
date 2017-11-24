namespace LeHuuKhoa.Core.Models
{
    public class Feedback
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Message { get; set; }
    }
}