using System.ComponentModel.DataAnnotations;

namespace LeHuuKhoa.Core.ViewModels
{
    public class FeedbackViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập email")]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập nội dung")]
        public string Message { get; set; }
    }
}