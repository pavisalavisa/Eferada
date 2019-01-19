using Eferada.Data.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration() : this("dbo")
        {

        }

        public StudentConfiguration(string schema)
        {
            ToTable("Student", schema);
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Address)
                .HasColumnName("Address")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.AcademicYear)
                .HasColumnName("AcademicYear")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.StudentCardCode)
                .HasColumnName("StudentCardCode")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.BirthDateTime)
                .HasColumnName("BirthDateTime")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.EnrollmentYear)
                .HasColumnName("EnrollmentYear")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.StudentStatus)
                .HasColumnName("StudentStatus")
                .HasColumnType("int")
                .IsRequired();


            HasRequired(x => x.ApplicationUser)
                .WithRequiredPrincipal();

            HasRequired(x => x.Course)
                .WithMany(x => x.EnrolledStudents)
                .HasForeignKey(x => x.CourseId);
        }
    }
}