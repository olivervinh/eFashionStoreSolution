using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFahionStore.Common.ResponseViewModels.Catalog
{
    public class ProductJoinImage
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
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
        public string? SupplierName { get; set; }
        public string Image { get; set; }
    }
}
