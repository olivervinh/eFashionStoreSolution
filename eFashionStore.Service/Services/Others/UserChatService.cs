using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Others;
using eFashionStore.Model.Models.Others;
using eFashionStore.Service.Intrastructure;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface IUserChatService : IBaseService<UserChat>
    {

    }
    public class UserChatService : BaseService<UserChat>, IUserChatService
    {
        private IUserChatRepository _userChatRepository;
        public UserChatService(IBaseRepository<UserChat> repository, IUserChatRepository discoutCodeRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _userChatRepository = discoutCodeRepository;
        }

    }
}
