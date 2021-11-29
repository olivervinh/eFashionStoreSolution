using eFashionStore.Model.Models.WareHouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Catalogs
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal SellPrice { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal ImportPrice { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PromotionPrice { get; set; }
        public string Tag { get; set; }
        public string Guide { get; set; }
        public string Ingredient { get; set; }
        public string StatusProduct { get; set; }
        public bool IsActive { get; set; }
        public int Gender { get; set; } //1: nam, 2 : nữ,
        public int? FkBrandId { get; set; }
        [ForeignKey("FkBrandId")]
        public virtual Brand Brand { get; set; }
        public int? FkCategoryId { get; set; }
        [ForeignKey("FkCategoryId")]
        public virtual Category Category { get; set; }
      
        public int? FkSupplierId { get; set; }
        [ForeignKey("FkSupplierId")]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
        public virtual ICollection<ImageProduct> ImageProducts { get; set; }

    }
}
