using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Orders
{
    public class DiscountCode
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal ValueDiscountPrice { get; set; }
    }
}
