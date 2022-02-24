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
    public interface IImageProductRepository : IBaseRepository<ImageProduct>
    {
        public Task<IEnumerable<ImageProduct>> GetImageProductsBaseFkBlogId(int FkProductId);
    }
    public class ImageProductRepository : BaseRepository<ImageProduct>, IImageProductRepository
    {
        private readonly EFashionStoreDbContext _context;
        public ImageProductRepository(EFashionStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImageProduct>> GetImageProductsBaseFkBlogId(int FkProductId)
        {
            return await _context.ImageProducts.Where(x => x.FkProductId == FkProductId).ToArrayAsync();
        }
    }
}