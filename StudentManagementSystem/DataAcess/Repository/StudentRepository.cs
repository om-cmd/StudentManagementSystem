using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.DataAcess.Repository;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.DataAcess.Repository
{
    public class StudentRepository : IStudentInterface
    {
        private readonly StudentDbContext _db;
        private readonly IMapper _mapper;

        public StudentRepository(StudentDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Student Create(StudentViewModel studentViewModel)
        {
            var student = _mapper.Map<Student>(studentViewModel);

            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public StudentViewModel Delete(int id)
        {
            var student = _db.Students.FirstOrDefault(x => x.StudentID == id);
            if (student != null)
            {
                _db.Students.Remove(student);
                _db.SaveChanges();
            }
            return _mapper.Map<StudentViewModel>(student);
        }

        public Student Edit(StudentViewModel studentChanges)
        {
            var student = _mapper.Map<Student>(studentChanges);
            _db.Entry(student).State = EntityState.Modified;
            _db.SaveChanges();
            return (student);
        }

        public ICollection<StudentViewModel> GetAllStudents()
        {
            var students = _db.Students.ToList();
            return _mapper.Map<List<StudentViewModel>>(students);
        }

        public StudentViewModel GetStudent(int id)
        {
            var students = _db.Students.FirstOrDefault(x => x.StudentID == id);
            return _mapper.Map<StudentViewModel>(students);
        }
    }
}

