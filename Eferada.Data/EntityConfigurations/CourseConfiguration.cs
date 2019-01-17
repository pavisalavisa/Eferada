using Eferada.Data.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration() : this("dbo")
        {

        }

        public CourseConfiguration(string schema)
        {
            ToTable("Course", schema);
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
                .HasMaxLength(50);

            Property(x => x.DurationInYears)
                .HasColumnName("DurationInYears")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}