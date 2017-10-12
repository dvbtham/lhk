using System.ComponentModel.DataAnnotations;

namespace LeHuuKhoa.Core.ViewModels
{
    public class PageViewModel
    {
        [StringLength(256, ErrorMessage = "Chỉ nhập id ít hơn 256 ký tự")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên trang")]
        [StringLength(256, ErrorMessage = "Chỉ nhập tên trang ít hơn 256 ký tự")]
        [Display(Name = "Tên trang")]
        public string Name { get; set; }
        
        [StringLength(256, ErrorMessage = "Độ dài ký tự ảnh nền ít hơn 256 ký tự")]
        [Display(Name = "Ảnh nền")]
        public string BackgroundImage { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập nội dung")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
    }
}