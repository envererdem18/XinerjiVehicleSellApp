using System.Collections.Generic;
using System.Threading.Tasks;
using XinerjiVehicleSellApp.Model.Entities;

namespace XinerjiVehicleSellApp.Service.Abstract
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> getAll();
        Task<Vehicle> Get(int id);
        Task<Vehicle> Add(Vehicle customer);
        Task<Vehicle> Update(Vehicle customer);
        Task Remove(int id);
    }
}
