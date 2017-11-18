using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LeHuuKhoa.Core.Models;

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

        [Required(ErrorMessage = "Bắt buộc phải nhập giới thiệu")]
        [MinLength(5, ErrorMessage = "Nội dung phải nhập ít nhất 5 ký tự")]
        public string Descriptions { get; set; }

    }
    public class PostCategoryClientViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
        
        public byte DisplayOrder { get; set; }
        
        public string ImageUrl { get; set; }

        public string BackgroundImage { get; set; }

        public string ShortDescriptions { get; set; }

        public string Descriptions { get; set; }

        public IList<Post> Posts { get; set; } = new List<Post>();

    }
}