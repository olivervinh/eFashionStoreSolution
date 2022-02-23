using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Model.Models.Users;
using eFashionStore.Service.Intrastructure;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface IAuthHistoryService : IBaseService<AuthHistory>
    {

    }
    public class AuthHistoryService : BaseService<AuthHistory>, IAuthHistoryService
    {
        private IAuthHistoryRepository _authHistoryRepository;
        public AuthHistoryService(IBaseRepository<AuthHistory> repository, IAuthHistoryRepository authHistoryRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _authHistoryRepository = authHistoryRepository;
        }

    }
}
