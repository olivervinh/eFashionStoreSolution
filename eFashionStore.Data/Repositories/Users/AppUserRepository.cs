using eFashionStore.Data.EF;
using eFashionStore.Data.Infrastructure;
using eFashionStore.Model.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFashionStore.Data.Repositories.Users
{
    public interface IAppUserRepository : IBaseRepository<AppUser>
    {
    }
    public class AccountRespository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AccountRespository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}