using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using StudentManagementSystem.Data;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.DataAcess.Repository
{
    public class CourcesRepository : ICourcesInterface
    {
        private readonly StudentDbContext _db;
        private readonly IMapper _mapper;
         
        public CourcesRepository(StudentDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public Cources Create(CourcesViewModel cources)
        {
            var cource = _mapper.Map<Cources>(cources);

            _db.Cources.Add(cource);
            _db.SaveChanges();
            return cource;

        }

        public CourcesViewModel Delete(int id)
        {
            var cource = _db.Cources.FirstOrDefaultAsync(x=>x.CourseID == id);
            if (cource != null)
            {
            _db.Remove(cource);
            _db.SaveChanges();
            }
            return _mapper.Map<CourcesViewModel>(cource);
        }

        public Cources Edit(CourcesViewModel courcesChanges)
        {
            var cource = _mapper.Map<Cources>(courcesChanges);
            _db.Entry(cource).State = EntityState.Modified;
            _db.SaveChanges();
            return (cource);


        }

        public ICollection<CourcesViewModel> GetAllCources()
        {
            var cource = _db.Cources.ToList();
            return _mapper.Map<List<CourcesViewModel>>(cource);
        }

        public CourcesViewModel GetCources(int id)
        {
            var cource = _db.Cources.FirstOrDefault(x=>x.CourseID == id);
            return _mapper.Map<CourcesViewModel>(cource);
        }
    }
}
