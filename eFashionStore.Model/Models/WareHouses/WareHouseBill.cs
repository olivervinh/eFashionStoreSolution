using eFashionStore.Model.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.WareHouses
{
    public class WareHouseBill
    {
        [Key]
        public int Id { get; set; }
        public string DocumentCode { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Total { get; set; }
        public string Note { get; set; }
        public string FkAppUserId { get; set; }
        [ForeignKey("FkAppUserId")]
        public virtual AppUser AppUser { get; set; }
        public int? FkSupplierId { get; set; }
        [ForeignKey("FkSupplierId")]
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<WareHouseBillDetail> WareHouseBillDetails { get; set; }
    }
}
