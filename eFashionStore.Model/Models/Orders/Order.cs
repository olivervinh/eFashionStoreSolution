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
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Note { get; set; } //ghi chu
        public int? Status { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Wards { get; set; }
        public string Address { get; set; }
        public string? FkAppUserId { get; set; }
        [ForeignKey("FkAppUserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
