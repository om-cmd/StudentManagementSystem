using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentManagementSystem.Data;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;
using System.Collections.Generic;

namespace StudentManagementSystem.DataAcess.Repository
{
    public class FacultyRepository : IFacultyInterface
    {
        private readonly StudentDbContext _db;
        private readonly IMapper _mapper;
        public FacultyRepository(StudentDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Faculty Create(FacultyViewModel faculty)
        {

            var faculti = _mapper.Map<Faculty>(faculty);

            _db.Faculty.Add(faculti);
            _db.SaveChanges();
            return faculti;

        }

        public FacultyViewModel Delete(int id)
        {
            var faculti = _db.Faculty.FirstOrDefault(x => x.FacultyID == id);
           if (faculti != null)
            {
                _db.Remove(faculti);
                _db.SaveChanges();
            }
           return _mapper.Map<FacultyViewModel>(faculti);
        }

        public Faculty Edit(FacultyViewModel facultyChanges)
        {
            var faculty = _mapper.Map<Faculty>(facultyChanges);
            _db.Entry(faculty).State= EntityState.Modified;
            _db.SaveChanges();
            return (faculty);

        }

        public ICollection<FacultyViewModel> GetAllFaculty()
        {
            var faculty = _db.Faculty.ToList();
            return _mapper.Map<List< FacultyViewModel>>(faculty);
        }

        public FacultyViewModel GetFaculty(int id)
        {
            var faculty = _db.Faculty.FirstOrDefault(x=>x.FacultyID==id);
            return _mapper.Map<FacultyViewModel>(faculty);
        }
    }
}
