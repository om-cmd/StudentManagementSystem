using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }
        [Required]
        public string StudentEmail { get; set; }
        [Required]
        public string StudentPhoneNumber { get; set; }
        [Required]
        public string StudentAddress { get; set; }
    }
}
