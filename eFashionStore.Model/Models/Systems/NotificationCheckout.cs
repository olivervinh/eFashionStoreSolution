using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Systems
{
    public class NotificationCheckout
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
    }
}
