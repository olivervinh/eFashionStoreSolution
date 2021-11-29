using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Others
{
    public interface IUserChatRepository : IRepository<UserChat>
    {
    }
    public class UserChatRepository : RepositoryBase<UserChat>, IUserChatRepository
    {
        public UserChatRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}