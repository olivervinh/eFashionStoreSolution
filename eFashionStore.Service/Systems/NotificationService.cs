using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Systems;
using eFashionStore.Model.Models.Systems;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Systems
{
    public interface INotificationService
    {
        Notification Add(Notification Notification);

        void Update(Notification Notification);

        Notification Delete(int id);

        IEnumerable<Notification> GetAll();

        IEnumerable<Notification> GetAll(string keyword);

        IEnumerable<Notification> GetAllByParentId(int parentId);

        Notification GetById(int id);

        Task<bool> SaveAsync();
    }
    public class NotificationService : INotificationService
    {
        private INotificationRepository _notificationRepository;
        private IUnitOfWork _unitOfWork;
        public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork)
        {
            this._notificationRepository = notificationRepository;
            this._unitOfWork = unitOfWork;
        }
        public Notification Add(Notification Notification)
        {
            return _notificationRepository.Add(Notification);
        }

        public Notification Delete(int id)
        {
            return _notificationRepository.Delete(id);
        }

        public IEnumerable<Notification> GetAll()
        {
            return _notificationRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Notification> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Notification> GetAllByParentId(int parentId)
        {
            return _notificationRepository.GetMulti(x =>x.Id == parentId);
        }

        public Notification GetById(int id)
        {
            return _notificationRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Notification Notification)
        {
            _notificationRepository.Update(Notification);
        }
    }
}
