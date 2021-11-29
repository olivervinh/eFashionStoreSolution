using eFashionStore.Model.Models.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Catalogs
{
    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }
        public int InventoryQuantity { get; set; }
        public int? FkProductId { get; set; }
        [ForeignKey("FkProductId")]
        public virtual Product Product { get; set; }
        public int? FkColorId { get; set; }
        [ForeignKey("FkColorId")]
        public virtual Color Color { get; set; }
        public int? FkSizeId { get; set; }
        [ForeignKey("FkSizeId")]
        public virtual Size Size { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
