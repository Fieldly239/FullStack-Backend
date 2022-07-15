using Student.Models;

namespace Student.Repositories
{
    public interface ICarsTableRepository
    {
        Task<IEnumerable<CarsTable>> GetAll();
        Task<CarsTable> GetById(int id);
        Task<IEnumerable<CarsTable>> GetByUserId(int id);
        Task<int> Add(CarsTable carsTable);
        Task<int> Update(CarsTable carsTable);
        Task<int> Delete(int id);
    }
}
