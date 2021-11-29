using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Users;
using eFashionStore.Model.Models.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Systems
{
    public interface IJobSeekerService
    {
        JobSeeker Add(JobSeeker JobSeeker);

        void Update(JobSeeker JobSeeker);

        JobSeeker Delete(int id);

        IEnumerable<JobSeeker> GetAll();

        IEnumerable<JobSeeker> GetAll(string keyword);

        IEnumerable<JobSeeker> GetAllByParentId(int parentId);

        JobSeeker GetById(int id);

        Task<bool> SaveAsync();
    }
    public class JobSeekerService : IJobSeekerService
    {
        private IJobSeekerRepository _JobSeekerRepository;
        private IUnitOfWork _unitOfWork;
        public JobSeekerService(IJobSeekerRepository JobSeekerRepository, IUnitOfWork unitOfWork)
        {
            this._JobSeekerRepository = JobSeekerRepository;
            this._unitOfWork = unitOfWork;
        }
        public JobSeeker Add(JobSeeker JobSeeker)
        {
            return _JobSeekerRepository.Add(JobSeeker);
        }

        public JobSeeker Delete(int id)
        {
            return _JobSeekerRepository.Delete(id);
        }

        public IEnumerable<JobSeeker> GetAll()
        {
            return _JobSeekerRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<JobSeeker> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<JobSeeker> GetAllByParentId(int parentId)
        {
            return _JobSeekerRepository.GetMulti(x =>x.Id == parentId);
        }

        public JobSeeker GetById(int id)
        {
            return _JobSeekerRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(JobSeeker JobSeeker)
        {
            _JobSeekerRepository.Update(JobSeeker);
        }
    }
}
