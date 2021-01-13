using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;
using XinerjiVehicleSellApp.Model.Entities;
using XinerjiVehicleSellApp.Service.Abstract;

namespace XinerjiVehicleSellApp.Service.Service
{
    public class SellService : ISellService
    {
        private readonly IDbConnection db;
        public SellService(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<Sales> SellVehicleToCustomer(int id, int customerId, int vehicleId)
        {
            var sql = "INSERT INTO Sales ( Id, CustomerId, VehicleId ) VALUES ( @Id, @CustomerId, @VehicleId );"
                + " SELECT CAST(SCOPE_IDENTITY() as INT); ";
            return await db.QuerySingleAsync<Sales>(sql, new { id, customerId, vehicleId });
        }
    }
}
