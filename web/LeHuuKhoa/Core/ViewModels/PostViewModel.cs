using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using LeHuuKhoa.Core.Models;
using LeHuuKhoa.Core.Utilities;

namespace LeHuuKhoa.Core.ViewModels
{
    public class PostViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề bài viết")]
        [MaxLength(100, ErrorMessage = "Chỉ nhập tối đa 100 ký tự")]
        public string Title { get; set; }
        
        public string Slug { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tóm tắt bài viết")]
        [MaxLength(1000, ErrorMessage = "Chỉ nhập tối đa 1000 ký tự")]
        public string Descriptions { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập nội dung")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn danh mục bài viết")]
        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public string AuthorName { get; set; }

        public int Views { get; set; } = 0;

        public bool IsPopularPost { get; set; }

        public SelectList CategoryList { get; set; }

        public PostViewModel()
        {
            if (Title != null)
                Slug = SlugHelper.ToUnsignString(Title);
        }
    }
}