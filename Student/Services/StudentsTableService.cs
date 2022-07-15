using Student.Models;
using Student.Repositories;

namespace Student.Services
{
    public class StudentsTableService : IStudentsTableService
    {
        private readonly IStudentsTableRepository _studentsTableRepository;

        public StudentsTableService(IStudentsTableRepository studentsTableRepository)
        {
            _studentsTableRepository = studentsTableRepository;
        }
        public async Task<IEnumerable<StudentsTable>> GetAll()
        {
            var studentsTable = await _studentsTableRepository.GetAll();
            var resp = studentsTable.OrderByDescending(m => m.Name);
            return resp;
        }
        public async Task<StudentsTable> GetById(int id)
        {
            return await _studentsTableRepository.GetById(id);
        }
        public async Task<IEnumerable<StudentsTable>> GetByUserId(int id)
        {
            return await _studentsTableRepository.GetByUserId(id);
        }
        public async Task<bool> Add(StudentsTable studentsTable)
        {
            var studentsTableList = await _studentsTableRepository.GetAll();
            var isDuplicate = studentsTableList.Where(m => m.Name == studentsTable.Name);
            if (isDuplicate.Count() > 0)
            {
                throw new Exception("Error studentsTable is Duplicate");
            }
            return await _studentsTableRepository.Add(studentsTable) > 0;
        }
        public async Task<bool> Update(StudentsTable studentsTable)
        {
            var studentsTableList = await _studentsTableRepository.GetAll();
            var isDuplicate = studentsTableList.Where(m => m.Name == studentsTable.Name && m.Id != studentsTable.Id);
            if (isDuplicate.Count() > 0)
            {
                throw new Exception("Error studentsTable is Duplicate");
            }
            return await _studentsTableRepository.Update(studentsTable) > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var studentTable = await _studentsTableRepository.GetById(id);
            if (studentTable == null)
            {
                throw new Exception("Error studentsTable is Duplicate");
            }
            return await _studentsTableRepository.Delete(id) > 0;
        }
    }
}

