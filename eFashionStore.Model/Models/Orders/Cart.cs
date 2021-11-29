using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Model.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Orders
{
    public class Cart
    {
        public Cart()
        {
            Quantity = 1;
        }
        [Key]
        public int Id { get; set; }

        public decimal? SellPrice { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string? FkAppUserId { get; set; }
        [ForeignKey("FkAppUserId")]
        public virtual AppUser AppUser { get; set; }

        public int? FkProductId { get; set; }

        [ForeignKey("FkProductId")]
        public virtual Product Product { get; set; }
        public int? FkProductVariantId { get; set; }
        [ForeignKey("FkProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please types quantity value")]
        public int Quantity { get; set; }
    }
}
