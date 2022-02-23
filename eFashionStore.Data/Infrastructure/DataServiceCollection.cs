using eFahionStore.Common.Helpers;
using eFahionStore.Common.RequestViewModels.Users;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Data.Repositories.Orders;
using eFashionStore.Data.Repositories.Others;
using eFashionStore.Data.Repositories.Systems;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Data.Repositories.WareHouses;
using eFashionStore.Model.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace eFashionStore.Data.Infrastructure
{
    public static class DataServiceCollection
    {
        private static string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private static readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        public static IConfiguration Configuration { get; }
        public static IServiceCollection DataRegisterServices(this IServiceCollection services)
        {
            #region Repositories Base
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            #endregion

            #region Repositories Catalogs
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<IImageBlogRepository, ImageBlogRepository>();
            services.AddTransient<IImageProductRepository, ImageProductRepository>();
            services.AddTransient<IProductLikeRepository, ProductLikeRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductReviewRepository, ProductReviewRepository>();
            services.AddTransient<IProductVariantRepository, ProductVariantRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();
            #endregion

            #region Repositories Orders
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            #endregion

            #region Repositories Others
            services.AddTransient<ICalendarToDoRepository, CalendarToDoRepository>();
            services.AddTransient<IUserChatRepository, UserChatRepository>();
            #endregion

            #region Repositories Systems
            services.AddTransient<INotificationCheckoutRepository, NotificationCheckoutRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            #endregion

            #region Repositories Users
            services.AddTransient<IAppUserRepository, AccountRespository>();
            services.AddTransient<IAuthHistoryRepository, AuthHistoryRepository>();
            services.AddTransient<IJobSeekerRepository, JobSeekerRepository>();
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });
            services.AddAutoMapper();
            #endregion

            #region Repositories WareHouses
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IWareHouseBillDetailRepository, WareHouseBillDetailRepository>();
            services.AddTransient<IWareHouseBillRepository, WareHouseBillRepository>();
            #endregion

            #region UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            return services;
        }
    }
}
