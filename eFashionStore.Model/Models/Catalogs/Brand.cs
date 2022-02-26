using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Catalogs
{
    public class Brand
    {
        public Brand()
        {

        }
        public Brand(int id,string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
