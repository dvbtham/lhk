using System.ComponentModel.DataAnnotations;

namespace LeHuuKhoa.Core.ViewModels
{
    public class PostCategoryViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập Tên danh mục")]
        [MaxLength(100, ErrorMessage = "Chỉ nhập nhiều nhất 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập thứ tự hiển thị")]
        public byte DisplayOrder { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải chọn ảnh")]
        [MaxLength(256, ErrorMessage = "Chỉ nhập nhiều nhất 256 ký tự")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải chọn ảnh bìa")]
        [MaxLength(256, ErrorMessage = "Chỉ nhập nhiều nhất 256 ký tự")]
        public string BackgroundImage { get; set; }
        
        public string ShortDescriptions { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập Nội dung")]
        [MinLength(5, ErrorMessage = "Nội dung phải nhập ít nhất 5 ký tự")]
        public string Descriptions { get; set; }

    }
}