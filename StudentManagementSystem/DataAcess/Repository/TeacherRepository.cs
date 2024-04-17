using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.Models;
using System.Linq;

namespace StudentManagementSystem.DataAcess.Repository
{
    public class TeacherRepository : ITeacherInterface
    {
        private readonly StudentDbContext _db;

        public TeacherRepository(StudentDbContext db)
        {
            _db = db;
        }

        public Teacher Create(Teacher teacher)
        {
            _db.Teachers.Add(teacher);
            _db.SaveChanges();
            return(teacher);
        }

        public Teacher Delete(int id)
        {
            var teacher = _db.Teachers.FirstOrDefault(x => x.TeacherID == id);
            if (teacher != null)
            {
                _db.Teachers.Remove(teacher);
                _db.SaveChanges();
            }
            return (teacher);
        }

        public Teacher Edit(Teacher teacherChanges)
        {
            var teacher = _db.Teachers.Attach(teacherChanges);
            teacher.State = EntityState.Modified;
            _db.SaveChanges();
           return(teacherChanges);
        }

        public ICollection<Teacher> GetAllTeachers()
        {
            return _db.Teachers.ToList();
        }

        public Teacher GetTeacher(int id)
        {
            return _db.Teachers.FirstOrDefault(x=>x.TeacherID==id) ;
        }
    }
}
