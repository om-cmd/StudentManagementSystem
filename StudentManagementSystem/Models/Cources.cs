using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Cources
    {
        [Key]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public ICollection<ChosenCources> ChosenCources { get; set; }


    }
}
