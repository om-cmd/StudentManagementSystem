using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public interface IUnitOfWork
    {
        public StudentDbContext Context { get; }
        public Student Student { get; }

        public Teacher Teacher { get; }

        public Cources Cources { get; }

        public Faculty Faculty { get; }

        //public IHttpContextAccessor _httpContextAccessor { get; }
        public ChosenCources ChosenCources { get; }

        public void Save();
       

    }


}
