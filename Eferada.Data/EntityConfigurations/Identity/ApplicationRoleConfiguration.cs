using Eferada.Data.Model.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations.Identity
{
    public class ApplicationRoleConfiguration :EntityTypeConfiguration<ApplicationRole>
    {
        public ApplicationRoleConfiguration() : this("dbo")
        {

        }

        public ApplicationRoleConfiguration(string schema)
        {
            ToTable("Roles", schema);
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

            HasMany(x => x.Users)
                .WithRequired()
                .HasForeignKey(x => x.UserId);
        }
    }
}