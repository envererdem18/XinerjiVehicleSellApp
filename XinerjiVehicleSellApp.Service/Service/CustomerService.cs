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
    public class CustomerService : ICustomerService
    {
        private readonly IDbConnection db;
        public CustomerService(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<Customer> Add(Customer customer)
        {
            var sql = "INSERT INTO Customer (Id, FullName, Password Budget ) VALUES(@Id, @FullName, @Password, @Budget);"
                + " SELECT CAST(SCOPE_IDENTITY() as INT); ";
            return await db.QuerySingleAsync<Customer>(sql, new { customer.Id, customer.FullName, customer.Password, customer.Budget });
        }

        public async Task<Customer> Get(int id)
        {
            var sql = "SELECT * FROM Customer WHERE Id = @Id";
            return await db.QuerySingleAsync<Customer>(sql, new { @Id = id });
        }

        public async Task<IEnumerable<Customer>> getAll()
        {
            var sql = "SELECT * FROM Customer";
            return await db.QueryAsync<Customer>(sql);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesOfACustomer(int id)
        {
            var sql = "SELECT * FROM Vehicle Where OwnerId = @id";
            return await db.QueryAsync<Vehicle>(sql);
        }

        public async Task Remove(int id)
        {
           var sql = "DELETE FROM Customer WHERE Id = @Id";
           await db.ExecuteAsync(sql, new { @Id = id });
        }

        public async Task<Customer> Update(Customer customer)
        {
            var sql = "UPDATE Customer SET FullName = @customer.FullName, Password = @customer.Password, Budget = @customer.Budget WHERE Id = @customer.Id";
           return await db.ExecuteScalarAsync<Customer>(sql, customer);
           
        }
    }
}
