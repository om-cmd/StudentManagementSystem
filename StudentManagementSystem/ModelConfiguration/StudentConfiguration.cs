using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.ModelConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("DTbl_Student");
            builder.HasKey(x => x.StudentID);
            builder.Property(x => x.StudentID).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.StudentName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.StudentAddress).HasMaxLength(50).IsRequired();
            builder.Property(x => x.StudentEmail).HasMaxLength(50).IsRequired();
            builder.Property(x => x.StudentPhoneNumber).HasMaxLength(50).IsRequired();
        }

    }
}
