using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using AutoMapper;
using LeHuuKhoa.Areas.Administrations.Controllers;
using LeHuuKhoa.Core.Models;

namespace LeHuuKhoa.Core.ViewModels
{
    public class ArticleSaveViewModel : Seoable
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Descriptions { get; set; }

        public string BackgroundImage { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ApplicationUser Author { get; set; }

        public int Views { get; set; } = 0;

        public bool IsPopularPost { get; set; } = false;

        public bool IsPublished { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public SelectList ArticleGroups { get; set; } 

        [IgnoreMap]
        public IList<ArticleAttributeVm> Attributes { get; protected set; } = new List<ArticleAttributeVm>();

        [IgnoreMap]
        public string Heading { get; set; }

        [IgnoreMap]
        public string Action
        {
            get
            {
                Expression<Func<ArticleController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<ArticleController, ActionResult>> create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression)?.Method.Name;
            }
        }
    }
}