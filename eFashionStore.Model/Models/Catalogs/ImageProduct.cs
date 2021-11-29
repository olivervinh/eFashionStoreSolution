using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Catalogs
{
    public class ImageProduct
    {
        public int? Id { get; set; }
        public string ImageName { get; set; }
        public int? FkProductId { get; set; }
        [ForeignKey("FkProductId")]
        public virtual Product Product { get; set; }
    }
}
