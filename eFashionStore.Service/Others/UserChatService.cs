using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Others;
using eFashionStore.Model.Models.Others;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Others
{
    public interface IUserChatService
    {
        UserChat Add(UserChat UserChat);

        void Update(UserChat UserChat);

        UserChat Delete(int id);

        IEnumerable<UserChat> GetAll();

        IEnumerable<UserChat> GetAll(string keyword);

        IEnumerable<UserChat> GetAllByParentId(int parentId);

        UserChat GetById(int id);

        Task<bool> SaveAsync();
    }
    public class UserChatService : IUserChatService
    {
        private IUserChatRepository _userChatRepository;
        private IUnitOfWork _unitOfWork;
        public UserChatService(IUserChatRepository userChatRepository, IUnitOfWork unitOfWork)
        {
            this._userChatRepository = userChatRepository;
            this._unitOfWork = unitOfWork;
        }
        public UserChat Add(UserChat UserChat)
        {
            return _userChatRepository.Add(UserChat);
        }

        public UserChat Delete(int id)
        {
            return _userChatRepository.Delete(id);
        }

        public IEnumerable<UserChat> GetAll()
        {
            return _userChatRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<UserChat> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<UserChat> GetAllByParentId(int parentId)
        {
            return _userChatRepository.GetMulti(x =>x.Id == parentId);
        }

        public UserChat GetById(int id)
        {
            return _userChatRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(UserChat UserChat)
        {
            _userChatRepository.Update(UserChat);
        }
    }
}
