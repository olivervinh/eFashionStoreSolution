using eFahionStore.Common.ResponseViewModels.RevenueStatistics;
using eFashionStore.Data.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.RevenueStatistics
{
    public interface IStatisticChartRepository
    {
        public List<SalesProduct> Top10BestSellingProducts();
    }
    public class StatisticChartRepository : IStatisticChartRepository
    {
        public List<SalesProduct> Top10BestSellingProducts()
        {
            List<SalesProduct> list = new List<SalesProduct>();

            string query = @" select Top(10) SanPhams.Ten+' '+Sizes.TenSize+' '+MauSacs.MaMau as 'Ten', cast(sum(ChiTietHoaDons.ThanhTien) as decimal(18,2)) as'ThanhTien'               
                            from SanPhams
                            inner join SanPhamBienThes
                            on SanPhams.Id = SanPhamBienThes.Id_SanPham
                            inner join MauSacs
                            on SanPhamBienThes.Id_Mau = MauSacs.Id
                            inner join Sizes
                            on SanPhamBienThes.SizeId = Sizes.Id
                            inner join ChiTietHoaDons
                            on SanPhamBienThes.Id_SanPham = ChiTietHoaDons.Id
                            inner join HoaDons
					        on ChiTietHoaDons.Id_HoaDon = HoaDons.Id
                            where HoaDons.TrangThai = 2
                            group by(SanPhams.Ten+' '+Sizes.TenSize+' '+MauSacs.MaMau)
                            order by cast(sum(ChiTietHoaDons.ThanhTien) as decimal(18,2)) desc
                            ";

            DataTable data = EFashionStoreDataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                SalesProduct salesProduct = new SalesProduct(item);
                list.Add(salesProduct);
            }

            return list;
        }
    }
}
