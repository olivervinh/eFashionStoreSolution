using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Model.Models.Users;
using eFashionStore.Service.Intrastructure;


namespace eFashionStore.Service.Services.Catalogs
{
    public interface IJobSeekerService : IBaseService<JobSeeker>
    {

    }
    public class JobSeekerService : BaseService<JobSeeker>, IJobSeekerService
    {
        private IJobSeekerRepository _jobSeekerRepository;
        public JobSeekerService(IBaseRepository<JobSeeker> repository, IJobSeekerRepository jobSeekerRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _jobSeekerRepository = jobSeekerRepository;
        }

    }
}
