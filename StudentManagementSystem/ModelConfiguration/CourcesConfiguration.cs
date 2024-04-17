using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.ModelConfiguration
{
    public class CourcesConfiguration : IEntityTypeConfiguration<Cources>
    {
        //yo db ma migration garnu agadi kati ko length testo afei set up garna milxa 
        public void Configure(EntityTypeBuilder<Cources> builder)
        {
            builder.ToTable("DTbl_Cources");
            builder.HasKey(x => x.CourseID);
            builder.Property(x => x.CourseID).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

        }
    }
}
