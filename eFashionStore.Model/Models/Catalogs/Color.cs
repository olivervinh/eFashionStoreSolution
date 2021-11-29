using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Catalogs
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FkCategoryId { get; set; }
        [ForeignKey("FkCategoryId")]
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
