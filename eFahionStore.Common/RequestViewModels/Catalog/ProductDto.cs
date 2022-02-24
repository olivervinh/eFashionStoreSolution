using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFahionStore.Common.RequestViewModels.Catalog
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SellPrice { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal? PromotionPrice { get; set; }
        public string Tag { get; set; }
        public string Guide { get; set; }
        public string Ingredient { get; set; }
        public string StatusProduct { get; set; }
        public bool IsActive { get; set; }
        public string Gender { get; set; }
        public int? FkBrandId { get; set; }
        public int? FkCategoryId { get; set; }
        public int? FkSupplierId { get; set; }
        public virtual ICollection<IFormFile> ImageProducts { get; set; }
    }
}
