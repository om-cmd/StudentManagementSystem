using StudentManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class ChosenCourcesViewModel
    {
        [Key]
        public int ChosenCourcesID { get; set; }
        public int StudentID { get; set; } //fk
        public int CourseID { get; set; } //fk

        public int FacultyID { get; set; }//fk 

        public string StudentName { get; set; }
        public string Title { get; set; }
        public string FacultyName { get; set; }

    }
}
