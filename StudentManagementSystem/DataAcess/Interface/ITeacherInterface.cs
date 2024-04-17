using StudentManagementSystem.Models;

namespace StudentManagementSystem.DataAcess.Interface
{
    public interface ITeacherInterface
    {
        Teacher GetTeacher(int id);
        ICollection<Teacher> GetAllTeachers();
        Teacher Create(Teacher teacher);
        Teacher Edit(Teacher teacherChanges);
        Teacher Delete(int id);

    }
}
