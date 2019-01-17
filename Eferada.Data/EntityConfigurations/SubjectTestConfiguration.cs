using Eferada.Data.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations
{
    public class SubjectTestConfiguration : EntityTypeConfiguration<SubjectTest>
    {
        public SubjectTestConfiguration() : this("dbo")
        {

        }

        public SubjectTestConfiguration(string schema)
        {
            ToTable("SubjectTest");
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.DateTime)
                .HasColumnName("DateTime")
                .HasColumnType("datetime")
                .IsRequired();

            Property(x => x.Term)
                .HasColumnName("Term")
                .HasColumnType("int")
                .IsRequired();

            HasRequired(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId);

            HasRequired(x => x.Subject)
                .WithMany()
                .HasForeignKey(x => x.SubjectId);
        }
    }
}