using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Orders;
using eFashionStore.Data.Repositories.Systems;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Model.Models.Orders;
using eFashionStore.Model.Models.Systems;
using eFashionStore.Service.Intrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface INotificationService : IBaseService<Notification>
    {

    }
    public class NotificationService : BaseService<Notification>, INotificationService
    {
        private INotificationRepository _notificationRepository;
        public NotificationService(IBaseRepository<Notification> repository, INotificationRepository notificationRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _notificationRepository = notificationRepository;
        }

    }
}
