using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public required string DepartmentName { get; set; }
        public int DepartmentNumberr { get; set; }
    }
}
