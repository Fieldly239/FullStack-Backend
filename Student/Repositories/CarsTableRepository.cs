using Dapper;
using Microsoft.Data.SqlClient;
using Student.Models;
using Student.Repositories.GenericRepository;

namespace Student.Repositories
{
    public class CarsTableRepository : GenericRepository<CarsTable>, ICarsTableRepository
    {
        private readonly IConfiguration _configuration;
        public CarsTableRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<CarsTable>> GetByUserId(int id)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var sqlCommand = "SELECT * FROM [CarsTable] WHERE [FK_StudentId] = @FK_StudentId";
                var res = await db.QueryAsync<CarsTable>(sqlCommand, new { FK_StudentId = id });
                return res.ToList();
            }
        }
        public override async Task<int> Add(CarsTable carsTable)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"INSERT INTO [CarsTable]
                                               ([CarName]
                                               ,[Brand]
                                               ,[Price]
                                               ,[RemainDebt]
                                               ,[FK_StudentId])
                                         VALUES
                                               (@CarName
                                               ,@Brand
                                               ,@Price
                                               ,@RemainDebt
                                               ,@FK_StudentId)");
                return await db.ExecuteAsync(sqlCommand, ParameterMapping(carsTable));
            }
        }
        public override async Task<int> Update(CarsTable carsTable)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"UPDATE [CarsTable]
                                           SET [CarName] = @CarName
                                              ,[Brand] = @Brand
                                              ,[Price] = @Price
                                              ,[RemainDebt] = @RemainDebt
                                              ,[FK_StudentId] = @FK_StudentId
                                         WHERE [Id] = @Id");
                return await db.ExecuteAsync(sqlCommand, ParameterMapping(carsTable));
            }
        }
        public override async Task<int> Delete(int id)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"DELETE FROM [CarsTable] WHERE [Id] = @Id");
                return await db.ExecuteAsync(sqlCommand, new { Id = id });
            }
        }



        private Object ParameterMapping(CarsTable carsTable)
        {
            return new
            {
                Id = carsTable.Id,
                CarName = carsTable.CarName,
                Brand = carsTable.Brand,
                Price = carsTable.Price,
                RemainDebt = carsTable.RemainDebt,
                FK_StudentId = carsTable.FK_StudentId
            };
        }
    }
}
