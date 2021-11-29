using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Model.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Systems
{
    public interface IAuthHistoryService
    {
        AuthHistory Add(AuthHistory AuthHistory);

        void Update(AuthHistory AuthHistory);

        AuthHistory Delete(int id);

        IEnumerable<AuthHistory> GetAll();

        IEnumerable<AuthHistory> GetAll(string keyword);

        IEnumerable<AuthHistory> GetAllByParentId(int parentId);

        AuthHistory GetById(int id);

        Task<bool> SaveAsync();
    }
    public class AuthHistoryService : IAuthHistoryService
    {
        private IAuthHistoryRepository _authHistoryRepository;
        private IUnitOfWork _unitOfWork;
        public AuthHistoryService(IAuthHistoryRepository authHistoryRepository, IUnitOfWork unitOfWork)
        {
            this._authHistoryRepository = authHistoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public AuthHistory Add(AuthHistory AuthHistory)
        {
            return _authHistoryRepository.Add(AuthHistory);
        }

        public AuthHistory Delete(int id)
        {
            return _authHistoryRepository.Delete(id);
        }

        public IEnumerable<AuthHistory> GetAll()
        {
            return _authHistoryRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<AuthHistory> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<AuthHistory> GetAllByParentId(int parentId)
        {
            return _authHistoryRepository.GetMulti(x =>x.Id == parentId);
        }

        public AuthHistory GetById(int id)
        {
            return _authHistoryRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(AuthHistory AuthHistory)
        {
            _authHistoryRepository.Update(AuthHistory);
        }
    }
}
