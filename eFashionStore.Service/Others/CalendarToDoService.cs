using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Others;
using eFashionStore.Model.Models.Others;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Others
{
    public interface ICalendarToDoService
    {
        CalendarToDo Add(CalendarToDo CalendarToDo);

        void Update(CalendarToDo CalendarToDo);

        CalendarToDo Delete(int id);

        IEnumerable<CalendarToDo> GetAll();

        IEnumerable<CalendarToDo> GetAll(string keyword);

        IEnumerable<CalendarToDo> GetAllByParentId(int parentId);

        CalendarToDo GetById(int id);

        Task<bool> SaveAsync();
    }
    public class CalendarToDoService : ICalendarToDoService
    {
        private ICalendarToDoRepository _calendarToDoRepository;
        private IUnitOfWork _unitOfWork;
        public CalendarToDoService(ICalendarToDoRepository calendarToDoRepository, IUnitOfWork unitOfWork)
        {
            _calendarToDoRepository = calendarToDoRepository;
            _unitOfWork = unitOfWork;
        }
        public CalendarToDo Add(CalendarToDo CalendarToDo)
        {
            return _calendarToDoRepository.Add(CalendarToDo);
        }

        public CalendarToDo Delete(int id)
        {
            return _calendarToDoRepository.Delete(id);
        }

        public IEnumerable<CalendarToDo> GetAll()
        {
            return _calendarToDoRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<CalendarToDo> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<CalendarToDo> GetAllByParentId(int parentId)
        {
            return _calendarToDoRepository.GetMulti(x => x.Id == parentId);
        }

        public CalendarToDo GetById(int id)
        {
            return _calendarToDoRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(CalendarToDo CalendarToDo)
        {
            _calendarToDoRepository.Update(CalendarToDo);
        }
    }
}
