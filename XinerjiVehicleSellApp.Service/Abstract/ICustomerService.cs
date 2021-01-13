using System.Collections.Generic;
using System.Threading.Tasks;
using XinerjiVehicleSellApp.Model.Entities;

namespace XinerjiVehicleSellApp.Service.Abstract
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> getAll();
        Task<Customer> Get(int id);
        Task<IEnumerable<Vehicle>> GetVehiclesOfACustomer(int id);

        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
        Task Remove(int id);
    }
}
