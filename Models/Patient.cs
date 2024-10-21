using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Mobile { get; set; }
        public int Age { get; set; }
        public required string Gender { get; set; }
    }
}
