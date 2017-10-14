using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Areas.Administrations.Controllers;

namespace LeHuuKhoa.Core.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên menu")]
        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(256, ErrorMessage = "Họ tên chỉ được phép nhập 256 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn Trang")]
        [Display(Name = "Trang")]
        public string PageId { get; set; }

        [IgnoreMap]
        public SelectList Pages { get; set; }

        [IgnoreMap]
        public string Heading { get; set; }

        [IgnoreMap]
        public string Action
        {
            get
            {
                Expression<Func<MenuController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<MenuController, ActionResult>> create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }
    }
}