using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoMapper;
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

        public string Images { get; set; }

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

        public string FileDownLoadLink { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nội dung mẫu")]
        public PostType PostType { get; set; }

        public string FileDownLoadId { get; set; }
        public FileDownLoad FileDownLoad { get; set; }

        public IList<PostFile> Files { get; set; } = new List<PostFile>();

        [IgnoreMap]
        public SelectList Categories { get; set; }

        [IgnoreMap]
        public SelectList PostTypeList { get; set; }

        }

    public class PdfViewModel
    {
        public string Path { get; set; }
        public IList<string> FileName { get; set; } = new List<string>();
    }

    public class ContentViewModel
    {
        public string Content { get; set; }
    }
    public class SlideViewModel
    {
        public IList<string> ImagesPath { get; set; } = new List<string>();
    }
    public class DownLoadViewModel
    {
        public Post Post { get; set; }
    }
    public class ViewCounterViewModel
    {
        public long PostId { get; set; }
    }
}