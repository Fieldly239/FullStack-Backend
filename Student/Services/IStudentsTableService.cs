using Student.Models;

namespace Student.Services
{
    public interface IStudentsTableService
    {
        Task<IEnumerable<StudentsTable>> GetAll();
        Task<StudentsTable> GetById(int id);
        Task<IEnumerable<StudentsTable>> GetByUserId(int id);
        Task<bool> Add(StudentsTable studentsTable);
        Task<bool> Update(StudentsTable studentsTable);
        Task<bool> Delete(int id);
    }
}
