using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Systems
{
    public interface INotificationCheckoutRepository : IRepository<NotificationCheckout>
    {
    }
    public class NotificationCheckoutRepository : RepositoryBase<NotificationCheckout>, INotificationCheckoutRepository
    {
        public NotificationCheckoutRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}