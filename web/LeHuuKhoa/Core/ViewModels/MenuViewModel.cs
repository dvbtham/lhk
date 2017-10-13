using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using LeHuuKhoa.Areas.Administrations.Controllers;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên menu")]
        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        [StringLength(256, ErrorMessage = "Họ tên chỉ được phép nhập 256 ký tự")]
        public string Name { get; set; }
        
        public string Heading { get; set; }

        [Display(Name = "Trang")]
        public ICollection<string> Pages { get; set; }

        public string PagesId { get; set; }

        public IEnumerable<Page> PageList { get; set; }

        public MenuViewModel()
        {
            Pages = new Collection<string>();
        }

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