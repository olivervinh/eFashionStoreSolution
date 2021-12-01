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
    public interface INotificationCheckoutRepository : IBaseRepository<NotificationCheckout>
    {
    }
    public class NotificationCheckoutRepository : BaseRepository<NotificationCheckout>, INotificationCheckoutRepository
    {
        public NotificationCheckoutRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}