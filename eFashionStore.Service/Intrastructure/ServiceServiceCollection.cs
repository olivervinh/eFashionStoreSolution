using eFashionStore.Data.Repositories.Catalogs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Service.Intrastructure
{
    public static class ServiceServiceCollection
    {
        public static IServiceCollection ServiceRegisterServices(this IServiceCollection services)
        {
            #region Repositories Catalogs
            services.AddScoped<IBlogService, BlogService>();
          
            #endregion

            #region Repositories Orders
           
            #endregion

            #region Repositories Others
           
            #endregion

            #region Repositories Systems
          
            #endregion

            #region Repositories Users
           
            #endregion

            #region Repositories WareHouses
           
            #endregion

            return services;
        }
    }
}
