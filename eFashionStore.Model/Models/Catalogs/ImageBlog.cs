﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Catalogs
{
    public class ImageBlog
    {
        [Key]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int? FkBlogId { get; set; }
        [ForeignKey("FkBlogId")]
        public virtual Blog Blog { get; set; }
    }
}
