using Eferada.Data.Model.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntitiyConfigurations.Identity
{
    public class ApplicationUserLoginConfiguration : EntityTypeConfiguration<ApplicationUserLogin>
    {
        public ApplicationUserLoginConfiguration() : this("dbo")
        {

        }

        public ApplicationUserLoginConfiguration(string schema)
        {
            ToTable("ApplicationUserLogin", schema);
            Ignore(x => x.Id);
            HasKey(x => new {x.UserId, x.LoginProvider, x.ProviderKey});

            Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x=>x.LoginProvider)
                .HasColumnName("LoginProvidet")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x=>x.ProviderKey)
                .HasColumnName("ProviderKey")
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(x => x.User).WithMany(x => x.Logins).HasForeignKey(x => x.UserId);
        }
    }
}