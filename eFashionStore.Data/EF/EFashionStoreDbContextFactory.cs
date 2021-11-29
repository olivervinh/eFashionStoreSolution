using eFahionStore.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace eFashionStore.Data.EF
{
    public class EFashionStoreDbContextFactory : IDesignTimeDbContextFactory<EFashionStoreDbContext>
    {
        public EFashionStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuider = new DbContextOptionsBuilder<EFashionStoreDbContext>();
            var connectionString = configuration.GetConnectionString(SystemContants.MainConnectionString);
            optionsBuider.UseSqlServer(connectionString);
            return new EFashionStoreDbContext(optionsBuider.Options);
        }
    }
}
