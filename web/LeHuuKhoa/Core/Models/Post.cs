﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeHuuKhoa.Core.Models
{
    public class Post
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public string CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual PostCategory Category { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public string Images { get; set; }
        
        public string AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
        
        public int Views { get; set; }

        public bool IsPopularPost { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public PostType PostType { get; set; }

        public IList<PostFile> Files { get; set; } = new List<PostFile>();

        public void Modify(string title, string description, string content,
            string categoryId, string metaDes, string metaKey, bool isPopular)
        {
            Title = title;
            Description = description;
            Content = content;
            CategoryId = categoryId;
            MetaDescription = metaDes;
            MetaKeyword = metaKey;
            IsPopularPost = isPopular;
        }
    }

    public enum PostType
    {
        Pdf = 10,
        Content = 20,
        PowerPoint = 30
    }
}