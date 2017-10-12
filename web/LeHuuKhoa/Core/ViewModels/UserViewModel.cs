using System;
using System.ComponentModel.DataAnnotations;

namespace LeHuuKhoa.Core.ViewModels
{
    public class UserViewModel
    {

        public string Id { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [StringLength(100, ErrorMessage = "Họ tên chỉ nhập 100 ký tự")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email là bắt buộc")]
        [StringLength(100, ErrorMessage = "Email chỉ nhập 100 ký tự")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string ImageUrl { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Bạn chưa chọn ngày sinh")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Bạn chưa chọn giới tính")]
        public string Gender { get; set; }
    }
}