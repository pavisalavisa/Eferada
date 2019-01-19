using Eferada.Data.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations
{
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration() : this("dbo")
        {

        }

        public SubjectConfiguration(string schema)
        {
            ToTable("Subject", schema);
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.ECTSNumber)
                .HasColumnName("ECTSNumber")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.ProfessorName)
                .HasColumnName("ProfessorName")
                .HasColumnType("varchar")
                .HasMaxLength(64)
                .IsRequired();

            HasMany(x => x.Courses)
                .WithMany(x => x.Subjects)
                .Map(cs =>
                {
                    cs.MapLeftKey("SubjectId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("SubjectCourse");
                });

            HasMany(x => x.Students)
                .WithMany(x => x.Subjects)
                .Map(cs =>
                {
                    cs.MapLeftKey("SubjectId");
                    cs.MapRightKey("StudentId");
                    cs.ToTable("SubjectStudent");
                });
        }
    }
}