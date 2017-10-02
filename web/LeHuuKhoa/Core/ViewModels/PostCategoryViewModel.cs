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

        [Required(ErrorMessage = "Bắt buộc phải nhập mô tả")]
        [MinLength(10, ErrorMessage = "Phải nhập ít nhất 10 ký tự")]
        [MaxLength(700, ErrorMessage = "Chỉ nhập nhiều nhất 700 ký tự")]
        public string Descriptions { get; set; }

    }
    public class CategoryViewModel
    {
        public string Name { get; set; }
        
        public byte DisplayOrder { get; set; }
        
        public string ImageUrl { get; set; }
        
        public string Descriptions { get; set; }

    }
}