using eFashionStore.Model.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Orders
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal? TotalItem { get; set; }
        public decimal? SellPrice { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public int? FkOrderId { get; set; }
        [ForeignKey("FkOrderId")]
        public int? FkProductId { get; set; }
        [ForeignKey("FkProductId")]
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public int? FkProductVariantId { get; set; }
        [ForeignKey("FkProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
