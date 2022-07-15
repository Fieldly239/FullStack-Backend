using Student.Models;

namespace Student.Services
{
    public interface ICarsTableService
    {
        Task<IEnumerable<CarsTable>> GetAll();
        Task<CarsTable> GetById(int id);
        Task<IEnumerable<CarsTable>> GetByUserId(int id);
        Task<bool> Add(CarsTable carsTable);
        Task<bool> Update(CarsTable carsTable);
        Task<bool> Delete(int id);
    }
}
