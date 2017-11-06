using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using LeHuuKhoa.Areas.Administrations.Controllers;

namespace LeHuuKhoa.Core.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập Tên danh mục")]
        [MaxLength(100, ErrorMessage = "Chỉ nhập nhiều nhất 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải nhập thứ tự hiển thị")]
        public byte DisplayOrder { get; set; }

        [Required(ErrorMessage = "Bắt buộc phải chọn ảnh")]
        [MaxLength(256, ErrorMessage = "Chỉ nhập nhiều nhất 256 ký tự")]
        public string Avatar { get; set; }
        
        [Required(ErrorMessage = "Bắt buộc phải nhập Mô tả")]
        [MinLength(5, ErrorMessage = "Mô tả phải nhập ít nhất 5 ký tự")]
        public string Descriptions { get; set; }

        public bool IsPublished { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<CategoryController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<CategoryController, ActionResult>> create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }

    }
  
}