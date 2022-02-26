using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Others;
using eFashionStore.Model.Models.Others;
using eFashionStore.Service.Intrastructure;


namespace eFashionStore.Service.Services.Others
{
    public interface ICalendarToDoService : IBaseService<CalendarToDo>
    {

    }
    public class CalendarToDoService : BaseService<CalendarToDo>, ICalendarToDoService
    {
        private ICalendarToDoRepository _calendarToDoRepository;
        public CalendarToDoService(IBaseRepository<CalendarToDo> repository, ICalendarToDoRepository calendarToDoRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _calendarToDoRepository = calendarToDoRepository;
        }

    }
}
