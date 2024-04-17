using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Models;

namespace StudentManagementSystem
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("DTbl_Teacher");
            builder.HasKey(x => x.TeacherID);
            builder.Property(x => x.TeacherID).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.TeacherName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TeacherAddress).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TeacherEmail).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TeacherPhoneNumber).HasMaxLength(50).IsRequired();
        }
    }
}
