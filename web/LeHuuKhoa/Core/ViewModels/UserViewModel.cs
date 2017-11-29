using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

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

        public List<string> MyRoles { get; set; }

        public List<IdentityRole> AllRoles { get; set; }
    }

    public class UserCreateViewModel
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

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, ErrorMessage = "Mật khẩu phải có ít nhất {0} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string ImageUrl { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Bạn chưa chọn ngày sinh")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Bạn chưa chọn giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}