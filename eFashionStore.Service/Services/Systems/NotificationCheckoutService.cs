using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Systems;
using eFashionStore.Model.Models.Systems;
using eFashionStore.Service.Intrastructure;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface INotificationCheckoutService : IBaseService<NotificationCheckout>
    {

    }
    public class NotificationCheckoutService : BaseService<NotificationCheckout>, INotificationCheckoutService
    {
        private INotificationCheckoutRepository _notificationCheckoutRepository;
        public NotificationCheckoutService(IBaseRepository<NotificationCheckout> repository, INotificationCheckoutRepository notificationCheckoutRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _notificationCheckoutRepository = notificationCheckoutRepository;
        }

    }
}
