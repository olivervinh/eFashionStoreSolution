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
    public interface IUserChatRepository : IBaseRepository<UserChat>
    {
    }
    public class UserChatRepository : BaseRepository<UserChat>, IUserChatRepository
    {
        public UserChatRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}