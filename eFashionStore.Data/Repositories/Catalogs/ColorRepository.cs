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
    public interface IColorRepository : IBaseRepository<Color>
    {
    }
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}