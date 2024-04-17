using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models
{
    public class ChosenCources
    {
        [Key]
        public int ChosenCourcesID { get; set; }
        public int StudentID { get; set; } //fk
        public int CourseID { get; set; } //fk

        public int FacultyID {  get; set; }//fk 
        //Referfence properties 

        [ForeignKey("StudentID")]
        public Student Student { get; set; }
        [ForeignKey("CourseID")]
        public Cources Courses { get; set; }

        [ForeignKey("FacultyID")]
        public Faculty Faculty { get; set; }
    }
}
