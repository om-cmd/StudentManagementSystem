using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class CourcesViewModel
    {
        [Key]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
    }
}
