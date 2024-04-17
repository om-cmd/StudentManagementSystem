using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }
        [Required]
        public string FacultyName { get; set; }

        public ICollection<ChosenCources> ChosenCources { get; set; }


    }
}
