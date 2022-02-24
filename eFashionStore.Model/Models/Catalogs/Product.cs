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
        public Product()
        {
        }

        public Product(int id, string name, string description, decimal sellPrice, decimal importPrice, decimal? promotionPrice, string tag, string guide, string ingredient, string statusProduct, bool isActive, string gender, int? fkBrandId, Brand brand, int? fkCategoryId, Category category, int? fkSupplierId, Supplier supplier, ICollection<ProductVariant> productVariants, ICollection<ImageProduct> imageProducts)
        {
            Id = id;
            Name = name;
            Description = description;
            SellPrice = sellPrice;
            ImportPrice = importPrice;
            PromotionPrice = promotionPrice;
            Tag = tag;
            Guide = guide;
            Ingredient = ingredient;
            StatusProduct = statusProduct;
            IsActive = isActive;
            Gender = gender;
            FkBrandId = fkBrandId;
            Brand = brand;
            FkCategoryId = fkCategoryId;
            Category = category;
            FkSupplierId = fkSupplierId;
            Supplier = supplier;
            ProductVariants = productVariants;
            ImageProducts = imageProducts;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ImportPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PromotionPrice { get; set; }
        public string Tag { get; set; }
        public string Guide { get; set; }
        public string Ingredient { get; set; }
        public string StatusProduct { get; set; }
        public bool IsActive { get; set; }
        public string Gender { get; set; } //1: nam, 2 : nữ,
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
