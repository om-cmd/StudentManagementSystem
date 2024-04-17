using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.DataAcess.Interface
{
    public interface IStudentInterface
    {
        StudentViewModel GetStudent(int id);
        ICollection<StudentViewModel> GetAllStudents();
        Student Create(StudentViewModel studentViewModel);
        Student Edit(StudentViewModel studentChanges);
        StudentViewModel Delete(int id);

    }
}
