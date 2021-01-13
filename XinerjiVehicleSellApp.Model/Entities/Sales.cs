using System.ComponentModel.DataAnnotations;

namespace XinerjiVehicleSellApp.Model.Entities
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
    }
}
