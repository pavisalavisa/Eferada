using System.Data.Entity.ModelConfiguration;
using Eferada.Data.Model.Entities;

namespace Eferada.Data.EntityConfigurations
{
    public class StudentSubjectTestConfiguration : EntityTypeConfiguration<StudentSubjectTest>
    {
        public StudentSubjectTestConfiguration() : this("dbo")
        {

        }

        public StudentSubjectTestConfiguration(string schema)
        {
            ToTable("StudentSubjectTest");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.SubjectTestId)
                .HasColumnName("SubjectTestId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.StudentId)
                .HasColumnName("StudentId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Participated)
                .HasColumnName("Participated")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.Grade)
                .HasColumnName("Grade")
                .HasColumnType("int")
                .IsRequired();

            HasRequired(x => x.Student)
                .WithMany(x => x.StudentSubjectTests)
                .HasForeignKey(x => x.StudentId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.SubjectTest)
                .WithMany()
                .HasForeignKey(x => x.SubjectTestId)
                .WillCascadeOnDelete(false);

        }
    }
}