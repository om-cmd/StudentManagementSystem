using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.DataAcess.Interface
{
    public interface IFacultyInterface
    {
        FacultyViewModel GetFaculty(int id);
        ICollection<FacultyViewModel> GetAllFaculty();
        Faculty Create(FacultyViewModel faculty);
        Faculty Edit(FacultyViewModel facultyChanges);
        FacultyViewModel Delete(int id);
    }
}
