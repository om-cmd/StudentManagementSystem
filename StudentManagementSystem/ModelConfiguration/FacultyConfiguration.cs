using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.ModelConfiguration
{

    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("DTbl_Faculty");
            builder.HasKey(x => x.FacultyID);
            builder.Property(x => x.FacultyID).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.FacultyName).HasMaxLength(50).IsRequired();
           
        }

    }

}
