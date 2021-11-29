using eFashionStore.Service.Catalogs;
using eFashionStore.Service.Orders;
using eFashionStore.Service.Others;
using eFashionStore.Service.Systems;
using eFashionStore.Service.Users;
using eFashionStore.Service.WareHouses;
using Microsoft.Extensions.DependencyInjection;

namespace eFashionStore.Service.ServiceCollection
{
    public static class ServiceCollection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region Repositories Catalogs
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IImageBlogService, ImageBlogService>();
            services.AddScoped<IImageProductService, ImageProductService>();
            services.AddScoped<IProductLikeService, ProductLikeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductReviewService, ProductReviewService>();
            services.AddScoped<IProductVariantService, ProductVariantService>();
            services.AddScoped<ISizeService, SizeService>();
            #endregion

            #region Repositories Orders
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            #endregion

            #region Repositories Others
            services.AddScoped<ICalendarToDoService, CalendarToDoService>();
            services.AddScoped<IUserChatService, UserChatService>();
            #endregion

            #region Repositories Systems
            services.AddScoped<INotificationCheckoutService, NotificationCheckoutService>();
            services.AddScoped<INotificationService, NotificationService>();
            #endregion

            #region Repositories Users
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAuthHistoryService, AuthHistoryService>();
            services.AddScoped<IJobSeekerService, JobSeekerService>();
            #endregion

            #region Repositories WareHouses
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IWareHouseBillDetailService, WareHouseBillDetailService>();
            services.AddScoped<IWareHouseBillService, WareHouseBillService>();
            #endregion

            return services;
        }
    }
}
