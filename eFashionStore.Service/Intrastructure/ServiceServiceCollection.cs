using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Service.Services.Catalogs;
using eFashionStore.Service.Services.Users;
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
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            #region Repositories Catalogs
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IImageBlogService, ImageBlogService>();
            services.AddTransient<IImageProductService, ImageProductService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductReviewService, ProductReviewService>();
            services.AddTransient<IProductVariantService, ProductVariantService>();
            services.AddTransient<ISizeService, SizeService>();

            #endregion

            #region Repositories Orders
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IOrderService, OrderService>();
            #endregion

            #region Repositories Others
            services.AddTransient<ICalendarToDoService, CalendarToDoService>();
            services.AddTransient<IUserChatService, UserChatService>();
            #endregion

            #region Repositories Systems

            #endregion

            #region Repositories Users
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAuthHistoryService, AuthHistoryService>();
            services.AddTransient<IJobSeekerService, JobSeekerService>();
            #endregion

            #region Repositories WareHouses

            #endregion

            return services;
        }
    }
}
