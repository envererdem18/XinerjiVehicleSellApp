using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using XinerjiVehicleSellApp.Model.Entities;
using XinerjiVehicleSellApp.Service.Abstract;

namespace XinerjiVehicleSellApp.Service.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IDbConnection db;
        public VehicleService(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<Vehicle> Add(Vehicle vehicle)
        {
            var sql = "INSERT INTO Vehicle (Id, Brand, Model, Price ) VALUES(@Id, @Brand, @Model, @Price );"
               + " SELECT CAST(SCOPE_IDENTITY() as INT); ";
            return await db.QuerySingleAsync<Vehicle>(sql, new { vehicle.Id, vehicle.Brand, vehicle.Model, vehicle.Price });
        }

        public async Task<Vehicle> Get(int id)
        {
            var sql = "SELECT * FROM Vehicle WHERE Id = @Id";
            return await db.QuerySingleAsync<Vehicle>(sql, new { @Id = id });
        }

        public async Task<IEnumerable<Vehicle>> getAll()
        {
            var sql = "SELECT * FROM Vehicle";
            return await db.QueryAsync<Vehicle>(sql);
        }

        public async Task Remove(int id)
        {
            var sql = "DELETE FROM Customer WHERE Id = @Id";
            await db.ExecuteAsync(sql, new { @Id = id });
        }

        public async Task<Vehicle> Update(Vehicle vehicle)
        {
            var sql = "UPDATE Vehicle SET Brand = @vehicle.Brand, Model = @vehicle.Model, Price = @vehicle.Price WHERE Id = @customer.Id";
            return await db.ExecuteScalarAsync<Vehicle>(sql, vehicle);
        }
    }
}
