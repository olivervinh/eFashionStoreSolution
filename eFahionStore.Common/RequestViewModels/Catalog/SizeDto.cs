using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFahionStore.Common.RequestViewModels.Catalog
{
    public class SizeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? FkCategoryId { get; set; }
    }
}
