using Dapper;
using Microsoft.Data.SqlClient;
using Student.Models;
using Student.Repositories.GenericRepository;

namespace Student.Repositories
{
    public class StudentsTableRepository : GenericRepository<StudentsTable>, IStudentsTableRepository
    {
        private readonly IConfiguration _configuration;
        public StudentsTableRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<StudentsTable>> GetByUserId(int Id)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var sqlCommand = "SELECT * FROM [StudentsTable] WHERE [Id] = @Id";
                var res = await db.QueryAsync<StudentsTable>(sqlCommand, new { Id = Id });
                return res.ToList();
            }
        }

        public override async Task<int> Add(StudentsTable studentsTable)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"INSERT INTO [StudentsTable]
                                               ([Name]
                                               ,[Address]
                                               ,[Email]
                                               ,[Contact])
                                         VALUES
                                               (@Name
                                               ,@Address
                                               ,@Email
                                               ,@Contact)");
                return await db.ExecuteAsync(sqlCommand, ParameterMapping(studentsTable));
            }
        }



        public override async Task<int> Update(StudentsTable studentsTable)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"UPDATE [StudentsTable]
                                           SET [Name] = @Name
                                              ,[Address] = @Address
                                              ,[Email] = @Email
                                              ,[Contact] = @Contact
                                         WHERE [Id] = @Id");
                return await db.ExecuteAsync(sqlCommand, ParameterMapping(studentsTable));
            }
        }

        public override async Task<int> Delete(int id)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"DELETE FROM [StudentsTable] WHERE [Id] = @Id");
                return await db.ExecuteAsync(sqlCommand, new { Id = id });
            }
        }

        private object ParameterMapping(StudentsTable studentsTable)
        {
            return new
            {
                Id = studentsTable.Id,
                Name = studentsTable.Name,
                Address = studentsTable.Address,
                Email = studentsTable.Email,
                Contact = studentsTable.Contact
            };

        }

    }
}

