using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Systems;
using eFashionStore.Model.Models.Systems;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Systems
{
    public interface INotificationCheckoutService
    {
        NotificationCheckout Add(NotificationCheckout NotificationCheckout);

        void Update(NotificationCheckout NotificationCheckout);

        NotificationCheckout Delete(int id);

        IEnumerable<NotificationCheckout> GetAll();

        IEnumerable<NotificationCheckout> GetAll(string keyword);

        IEnumerable<NotificationCheckout> GetAllByParentId(int parentId);

        NotificationCheckout GetById(int id);

        Task<bool> SaveAsync();
    }
    public class NotificationCheckoutService : INotificationCheckoutService
    {
        private INotificationCheckoutRepository _notificationCheckoutRepository;
        private IUnitOfWork _unitOfWork;
        public NotificationCheckoutService(INotificationCheckoutRepository notificationCheckoutRepository, IUnitOfWork unitOfWork)
        {
            _notificationCheckoutRepository = notificationCheckoutRepository;
            _unitOfWork = unitOfWork;
        }
        public NotificationCheckout Add(NotificationCheckout NotificationCheckout)
        {
            return _notificationCheckoutRepository.Add(NotificationCheckout);
        }

        public NotificationCheckout Delete(int id)
        {
            return _notificationCheckoutRepository.Delete(id);
        }

        public IEnumerable<NotificationCheckout> GetAll()
        {
            return _notificationCheckoutRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<NotificationCheckout> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<NotificationCheckout> GetAllByParentId(int parentId)
        {
            return _notificationCheckoutRepository.GetMulti(x => x.Id == parentId);
        }

        public NotificationCheckout GetById(int id)
        {
            return _notificationCheckoutRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(NotificationCheckout NotificationCheckout)
        {
            _notificationCheckoutRepository.Update(NotificationCheckout);
        }
    }
}
