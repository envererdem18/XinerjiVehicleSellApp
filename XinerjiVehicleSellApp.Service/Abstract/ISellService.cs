using System.Threading.Tasks;
using XinerjiVehicleSellApp.Model.Entities;

namespace XinerjiVehicleSellApp.Service.Abstract
{
    public interface ISellService
    {
        Task<Sales> SellVehicleToCustomer(int id, int customerId, int vehicleId);
    }
}
