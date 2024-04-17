using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.DataAcess.Repository
{
    public class ChosenCourcesRepository : IChosenCourcesInterface
    {
        private readonly StudentDbContext _db;
        private readonly IMapper _mapper;

        public ChosenCourcesRepository(StudentDbContext db, IMapper mapper) 
        {
            _db = db;
            _mapper = mapper;
        }

        IQueryable<Student> IChosenCourcesInterface.Students => _db.Students;

        IQueryable<Faculty> IChosenCourcesInterface.Faculty => _db.Faculty;

        IQueryable<Cources> IChosenCourcesInterface.Cources => _db.Cources;

        public ChosenCources Create(ChosenCourcesViewModel chosen)
        {
            var chosens =  _mapper.Map<ChosenCources>(chosen);
            _db.Add(chosens);
            _db.SaveChanges();
            return chosens;

        }

        public ChosenCourcesViewModel Delete(int id)
        {
            var chosen = _db.ChosenCources.FirstOrDefault(x=>x.ChosenCourcesID==id);
            if(chosen != null)
            {
                _db.Remove(chosen);
                _db.SaveChanges() ;
            }
            return _mapper.Map<ChosenCourcesViewModel>(chosen);
        }

        public ChosenCources Edit(ChosenCourcesViewModel chosenChanges)
        {
            var chosen = _mapper.Map<ChosenCources>(chosenChanges);
            _db.Entry(chosen).State = EntityState.Modified;
            _db.SaveChanges();
            return chosen;
        }

        public ICollection<ChosenCourcesViewModel> GetAllChosenCources()
        {
            var chosenCource = _db.ChosenCources.Include(x=>x.Student).Include(x=>x.Faculty).Include(x=>x.Courses);
            return _mapper.Map<List<ChosenCourcesViewModel>>(chosenCource);
        }

        public ChosenCourcesViewModel GetChosenCources(int id)
        {
            var chosenCource = _db.ChosenCources.Include(x => x.Student).Include(x => x.Faculty).Include(x => x.Courses).FirstOrDefault(x=>x.ChosenCourcesID==id);
            return _mapper.Map<ChosenCourcesViewModel>(chosenCource);
        }
    }
}
