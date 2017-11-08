using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Areas.Administrations.Controllers;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.ViewModels
{
    public class PostViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề bài viết")]
        [MaxLength(100, ErrorMessage = "Chỉ nhập tối đa 100 ký tự")]
        public string Title { get; set; }
        
        public string Slug { get; set; }
        
        public string Description { get; set; }
        
        public string Content { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn danh mục bài viết")]
        public string CategoryId { get; set; }

        public PostCategory Category { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime DateUpdated { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public int Views { get; set; } = 0;

        public bool IsPopularPost { get; set; } = false;

        public bool IsPublished { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public PostType PostType { get; set; }

        public IList<PostFile> Files { get; set; } = new List<PostFile>();

        [IgnoreMap]
        public SelectList Categories { get; set; }
        
    }
}