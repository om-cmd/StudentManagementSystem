using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class FacultyViewModel
    {
        [Key]
        public int FacultyID { get; set; }
        [Required]
        public string FacultyName { get; set; }
    }
}
