using Dapper;
using Microsoft.Data.SqlClient;

namespace Student.Repositories.GenericRepository
{
    public abstract class GenericRepository<T>
    {
        private readonly IConfiguration _configuration;
        protected readonly string connectionStrings = "";
        public GenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionStrings = _configuration.GetSection("ConnectionStrings:ConnectionString").Value;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var className = typeof(T).Name;
                var sqlCommand = $"SELECT * FROM {className}";
                var resp = await db.QueryAsync<T>(sqlCommand);
                return resp.ToList();

            }
        }

        public async Task<T> GetById(int id)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var className = typeof(T).Name;
                var sqlCommand = $"SELECT * FROM {className} WHERE [Id] = @Id";
                var resp = await db.QueryAsync<T>(sqlCommand, new { Id = id });
                return resp.FirstOrDefault();
            }
        }

        public abstract Task<int> Add(T model);
        public abstract Task<int> Update(T model);
        public abstract Task<int> Delete(int id);
    }
}
