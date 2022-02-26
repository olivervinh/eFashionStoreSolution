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
        public DiscountCode()
        {
        }

        public DiscountCode(int id, string code, decimal valueDiscountPrice)
        {
            Id = id;
            Code = code;
            ValueDiscountPrice = valueDiscountPrice;
        }

        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal ValueDiscountPrice { get; set; }
    }
}
