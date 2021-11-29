using eFashionStore.Model.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.WareHouses
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Info { get; set; }
        public string Address { get; set; }
        public virtual ICollection<WareHouseBill> WareHouseBills { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
