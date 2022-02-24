using eFahionStore.Common.ResponseViewModels.Catalog;
using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Catalogs
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        //public Task<IEnumerable<ProductJoinImage>> GetCustomProductsPaginationListAsync(int pageNumber, int pageSize);
    }
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly EFashionStoreDbContext _context;
        public ProductRepository(EFashionStoreDbContext context) : base(context)
        {
            _context = context;
        }

        //public Task<IEnumerable<ProductJoinImage>> GetCustomProductsPaginationListAsync(int pageNumber, int pageSize)
        //{
            
        //}
    }
}