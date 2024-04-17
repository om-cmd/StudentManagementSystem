using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.ModelConfiguration
{
    public class ChosenCourceConfiguration: IEntityTypeConfiguration<ChosenCources>
    {
        public void Configure(EntityTypeBuilder<ChosenCources> builder)
        {
            builder.ToTable("DTbl_ChosenCources");
            builder.HasKey(x => x.ChosenCourcesID);
            builder.Property(x => x.ChosenCourcesID).ValueGeneratedOnAdd().IsRequired();

            // Configure foreign key for StudentID
            builder.HasOne(cc => cc.Student)
                   .WithMany(s => s.ChosenCources)
                   .HasForeignKey(cc => cc.StudentID);

            // Configure foreign key for CourseID
            builder.HasOne(cc => cc.Courses)
                   .WithMany(c => c.ChosenCources)
                   .HasForeignKey(cc => cc.CourseID);

            // Configure foreign key for FacultyID
            builder.HasOne(cc => cc.Faculty)
                   .WithMany(c=> c.ChosenCources)
                   .HasForeignKey(cc => cc.FacultyID);


        }
    }
}
