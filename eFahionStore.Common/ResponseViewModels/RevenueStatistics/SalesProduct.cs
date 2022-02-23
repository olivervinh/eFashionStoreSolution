using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFahionStore.Common.ResponseViewModels.RevenueStatistics
{
    public class SalesProduct
    {
        public string ProductName;
        public decimal HighestSale;
        public SalesProduct(string productName, decimal highestSale)
        {
            ProductName = productName;
            HighestSale = highestSale;
        }
        public SalesProduct(DataRow row)
        {
            this.ProductName = row["ProductName"].ToString();
            this.HighestSale = (decimal)row["HighestSale"];
        }

    }
}
