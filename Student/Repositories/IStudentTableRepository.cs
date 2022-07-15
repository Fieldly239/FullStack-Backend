using Student.Models;

namespace Student.Repositories
{
    public interface IStudentsTableRepository
    {
        Task<IEnumerable<StudentsTable>> GetAll();
        Task<StudentsTable> GetById(int id);
        Task<IEnumerable<StudentsTable>> GetByUserId(int Id);
        Task<int> Add(StudentsTable studentsTable);
        Task<int> Update(StudentsTable studentsTable);
        Task<int> Delete(int id);
    }
}
