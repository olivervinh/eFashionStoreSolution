using eFashionStore.Model.Models;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Model.Models.Orders;
using eFashionStore.Model.Models.Others;
using eFashionStore.Model.Models.Systems;
using eFashionStore.Model.Models.Users;
using eFashionStore.Model.Models.WareHouses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.EF
{
    public class EFashionStoreDbContext : IdentityDbContext
    {
        public EFashionStoreDbContext(DbContextOptions<EFashionStoreDbContext> options) : base(options) 
        {
        }

        #region DbSet Catalogs
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ImageBlog> ImageBlogs { get; set; }
        public DbSet<ImageProduct> ImageProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLike> ProductLikes { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductLike> Size { get; set; }
        #endregion

        #region DbSet Orders
        public DbSet<Cart> Carts { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        #region DbSet Other
        public DbSet<CalendarToDo> CalendarToDos { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        #endregion

        #region DbSet Notification
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationCheckout> NotificationCheckouts { get; set; }
        #endregion

        #region DbSet User
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AuthHistory> AuthHistories { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        #endregion

        #region DbSet WareHouse
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WareHouseBill> WareHouseBills { get; set; }
        public DbSet<WareHouseBillDetail> WareHouseBillDetails { get; set; }
        #endregion
    }

}
