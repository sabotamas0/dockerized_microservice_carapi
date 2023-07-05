using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarApi.Models
{
    public class CarModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string HorsePower { get; set; }
    }
}
