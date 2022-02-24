using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Model.Models.Catalogs
{
    public class ImageProduct
    {
        public ImageProduct()
        {
        }

        public ImageProduct(int id, string imageName, bool isThumbnail, int? fkProductId, Product product)
        {
            Id = id;
            ImageName = imageName;
            IsThumbnail = isThumbnail;
            FkProductId = fkProductId;
            Product = product;
        }

        [Key]
        public int Id { get; set; }
        public string ImageName { get; set; }
        public bool IsThumbnail { get; set; }
        public int? FkProductId { get; set; }
        [ForeignKey("FkProductId")]
        public virtual Product Product { get; set; }
    }
}
