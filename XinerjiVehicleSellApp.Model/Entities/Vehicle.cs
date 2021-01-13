using System.ComponentModel.DataAnnotations;

namespace XinerjiVehicleSellApp.Model.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }
}
