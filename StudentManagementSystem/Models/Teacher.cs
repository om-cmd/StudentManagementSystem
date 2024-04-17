using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        [Required]
        [StringLength(50)]
        public string TeacherName { get; set; }
        [Required]
        public string TeacherEmail { get; set; }
        [Required]
        public string TeacherPhoneNumber { get; set; }
        [Required]
        public string TeacherAddress { get; set; }


    }
}
