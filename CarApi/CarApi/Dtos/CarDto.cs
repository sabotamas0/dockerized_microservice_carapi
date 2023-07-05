using System.ComponentModel.DataAnnotations;

namespace CarApi.Dtos
{
    public class CarDto
    {
        public string? LicenseNumber { get; set; }
        public string? OwnerName { get; set; }
        public string? HorsePower { get; set; }
    }
}
