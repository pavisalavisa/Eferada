using Eferada.Data.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration() : this("dbo")
        {

        }

        public EmployeeConfiguration(string schema)
        {
            ToTable("Employee", schema);
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Address)
                .HasColumnName("Address")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(64);

            HasRequired(x => x.ApplicationUser)
                .WithRequiredPrincipal();
        }
    }
}