using eFashionStore.Data.EF;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Properties
        private readonly EFashionStoreDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(EFashionStoreDbContext context,ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }
        #endregion
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
