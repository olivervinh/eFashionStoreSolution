using eFashionStore.Model.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Catalogs
{
    public class Blog
    {
        public Blog()
        {
        }

        public Blog(int id, string title, string content, ICollection<ImageBlog> imageBlogs, string fkAppUserId, AppUser appUser)
        {
            Id = id;
            Title = title;
            Content = content;
            ImageBlogs = imageBlogs;
            FkAppUserId = fkAppUserId;
            AppUser = appUser;
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ICollection<ImageBlog> ImageBlogs { get; set; }

        public string? FkAppUserId { get; set; }
        [ForeignKey("FkAppUserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
