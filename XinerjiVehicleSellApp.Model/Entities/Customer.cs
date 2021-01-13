using System.ComponentModel.DataAnnotations;

namespace XinerjiVehicleSellApp.Model.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public double Budget { get; set; }
    }
}
