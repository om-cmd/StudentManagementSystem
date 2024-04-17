using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(StudentDbContext studentDbContext, IHttpContextAccessor httpContextAccessor, Teacher teacher, Student student, Cources cources, Faculty faculty, ChosenCources chosenCources)

        {
            Context = studentDbContext;
            Teacher = teacher;
            Student = student;
            Cources = cources;
            Faculty = faculty;
            ChosenCources = chosenCources;
            _httpContextAccessor = httpContextAccessor;

           
        }
        public StudentDbContext Context { get; private set; }

        public Teacher Teacher { get; private set; }
        public Student Student { get; private set; }

        public Cources Cources { get; private set; }
        public Faculty Faculty { get; private set; }
        public ChosenCources ChosenCources { get; private set; }

        public IHttpContextAccessor _httpContextAccessor { get; private set; }


        public void Save()
        {
            Context.SaveChanges();
        }

    }
}
