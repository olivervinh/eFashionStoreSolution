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
    public interface IJobSeekerRepository : IRepository<JobSeeker>
    {
    }
    public class JobSeekerRepository : RepositoryBase<JobSeeker>, IJobSeekerRepository
    {
        public JobSeekerRepository(EFashionStoreDbContext context) : base(context)
        {

        }
    }
}