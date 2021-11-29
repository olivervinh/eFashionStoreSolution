using eFashionStore.Model.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.WareHouses
{
    public class WareHouseBillDetail
    {
        [Key]
        public int Id { get; set; }
        public int ImportQuantity { get; set; }
        public decimal TotalItem { get; set; }
        public int? FkWareHouseBillId { get; set; }
        [ForeignKey("FkWareHouseBillId")]
        public virtual WareHouseBill WareHouseBill { get; set; }
        public int? FkProductVariantId { get; set; }
        [ForeignKey("FkProductVariantId")]
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
