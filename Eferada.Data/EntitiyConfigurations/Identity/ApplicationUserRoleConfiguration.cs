using Eferada.Data.Model.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntitiyConfigurations.Identity
{
    public class ApplicationUserRoleConfiguration : EntityTypeConfiguration<ApplicationUserRole>
    {
        public ApplicationUserRoleConfiguration():this("dbo")
        {
            
        }

        public ApplicationUserRoleConfiguration(string schema)
        {
            ToTable("UserRoles", schema);
            HasKey(x => new {x.Id, x.UserId, x.RoleId});

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .HasColumnType("int")
                .IsRequired();

            HasRequired(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
            HasRequired(x => x.User).WithMany(x => x.Roles).HasForeignKey(x => x.UserId);
        }
    }
}