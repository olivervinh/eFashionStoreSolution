using eFashionStore.Data.Infrastructure;
using eFashionStore.Data.Repositories.Catalogs;
using eFashionStore.Model.Models.Catalogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.Service.Catalogs
{
    public interface IColorService
    {
        Color Add(Color Color);

        void Update(Color Color);

        Color Delete(int id);

        IEnumerable<Color> GetAll();

        IEnumerable<Color> GetAll(string keyword);

        IEnumerable<Color> GetAllByParentId(int parentId);

        Color GetById(int id);

        Task<bool> SaveAsync();
    }
    public class ColorService : IColorService
    {
        private IColorRepository _colorRepository;
        private IUnitOfWork _unitOfWork;
        public ColorService(IColorRepository colorRepository, IUnitOfWork unitOfWork)
        {
            this._colorRepository = colorRepository;
            this._unitOfWork = unitOfWork;
        }
        public Color Add(Color Color)
        {
            return _colorRepository.Add(Color);
        }

        public Color Delete(int id)
        {
            return _colorRepository.Delete(id);
        }

        public IEnumerable<Color> GetAll()
        {
            return _colorRepository.GetAll().OrderBy(x => x.Id);
        }

        public IEnumerable<Color> GetAll(string keyword)
        {
            return null;
        }

        public IEnumerable<Color> GetAllByParentId(int parentId)
        {
            return _colorRepository.GetMulti(x =>x.Id == parentId);
        }

        public Color GetById(int id)
        {
            return _colorRepository.GetSingleById(id);
        }

        public async Task<bool> SaveAsync()
        {
            await _unitOfWork.CommitAsync();
            return true;
        }

        public void Update(Color Color)
        {
            _colorRepository.Update(Color);
        }
    }
}
