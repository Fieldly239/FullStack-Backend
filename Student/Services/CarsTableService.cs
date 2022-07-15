using Student.Models;
using Student.Repositories;

namespace Student.Services
{
    public class CarsTableService : ICarsTableService
    {
        private readonly ICarsTableRepository _carsTableRepository;

        public CarsTableService(ICarsTableRepository carsTableRepository)
        {
            _carsTableRepository = carsTableRepository;
        }
        public async Task<IEnumerable<CarsTable>> GetAll()
        {
            var carsTable = await _carsTableRepository.GetAll();
            var resp = carsTable.OrderByDescending(m => m.CarName);
            return resp;
        }
        public async Task<CarsTable> GetById(int id)
        {
            return await _carsTableRepository.GetById(id);
        }

        public async Task<IEnumerable<CarsTable>> GetByUserId(int id)
        {
            return await _carsTableRepository.GetByUserId(id);
        }
        public async Task<bool> Add(CarsTable carsTable)
        {
            //validate dupicate
            var carsTableList = await _carsTableRepository.GetAll();
            var isDuplicate = carsTableList.Where(m => m.CarName == carsTable.CarName);
            if (isDuplicate.Count() > 0)
            {
                throw new Exception("Error! Feedbacks is duplicate");
            }
            return await _carsTableRepository.Add(carsTable) > 0;
        }
        public async Task<bool> Update(CarsTable carsTable)
        {
            var carsTableList = await _carsTableRepository.GetAll();
            var isDuplicate = carsTableList.Where(m => m.CarName == carsTable.CarName && m.Id != carsTable.Id);
            if (isDuplicate.Count() > 0)
            {
                throw new Exception("Error! Feedbacks is duplicate");
            }
            return await _carsTableRepository.Update(carsTable) > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var carsTable = await _carsTableRepository.GetById(id);
            if (carsTable == null)
            {
                throw new Exception("Error! Feedback not exist");
            }
            return await _carsTableRepository.Delete(id) > 0;
        }
    }
}
