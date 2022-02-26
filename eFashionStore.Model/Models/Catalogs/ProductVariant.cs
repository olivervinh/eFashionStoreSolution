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
        public ProductVariant()
        {
        }

        public ProductVariant(int id, int inventoryQuantity, int? fkProductId, Product product, int? fkColorId, Color color, int? fkSizeId, Size size, ICollection<OrderDetail> orderDetails)
        {
            Id = id;
            InventoryQuantity = inventoryQuantity;
            FkProductId = fkProductId;
            Product = product;
            FkColorId = fkColorId;
            Color = color;
            FkSizeId = fkSizeId;
            Size = size;
            OrderDetails = orderDetails;
        }

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
