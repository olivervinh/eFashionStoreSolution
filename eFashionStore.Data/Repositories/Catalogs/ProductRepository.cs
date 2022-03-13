using eFahionStore.Common.Helpers;
using eFahionStore.Common.ResponseViewModels.Catalog;
using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Catalogs
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<IEnumerable<Product>> GetCustomProductsPaginationListAsync(IQueryable<Product> queryableList, int pageNumber, int pageSize);
    }
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly EFashionStoreDbContext _context;
        public ProductRepository(EFashionStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetCustomProductsPaginationListAsync(IQueryable<Product> queryableList, int pageNumber, int pageSize)
        {
            var productsList = _context.Products.Include(x=>x.ImageProducts).Include(x => x.Category).Include(x => x.Brand).Include(x => x.Supplier).AsQueryable();
           return await PagedPaginationHelper<Product>.CreateAsync(productsList, pageNumber, pageSize);
        }
    }
}