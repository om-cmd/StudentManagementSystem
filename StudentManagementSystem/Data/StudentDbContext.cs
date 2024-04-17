using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.ModelConfiguration;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.UserModel;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Data
{
    public class StudentDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; } 
        public DbSet<Cources> Cources { get; set; }   
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<ChosenCources> ChosenCources {  get; set; }
        public DbSet<User> Users{ get; set; }



        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TeacherConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new FacultyConfiguration());
            builder.ApplyConfiguration(new CourcesConfiguration());
            builder.ApplyConfiguration(new ChosenCourceConfiguration());
            base.OnModelCreating(builder);
            
        }
        public DbSet<StudentManagementSystem.ViewModels.ChosenCourcesViewModel> ChosenCourcesViewModel { get; set; } = default!;

    }
}
