using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFahionStore.Common.RequestViewModels.Catalog
{
    public class ProductVariantDto
    {
        public int Id { get; set; }
        public int InventoryQuantity { get; set; }
        public int? FkProductId { get; set; }
        public int? FkColorId { get; set; }
        public int? FkSizeId { get; set; }
    }
}
