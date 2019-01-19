using Eferada.Data.Model.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations.Identity
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration() : this("dbo")
        {

        }

        public ApplicationUserConfiguration(string schema)
        {
            ToTable("Users", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).HasColumnName("UserName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.EmailConfirmed).HasColumnName("EmailConfirmed").HasColumnType("bit").IsRequired();
            Property(x => x.PasswordHash).HasColumnName("PasswordHash").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.SecurityStamp).HasColumnName("SecurityStamp").HasColumnType("nvarchar").IsOptional().HasMaxLength(100);
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(25);
            Property(x => x.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed").HasColumnType("bit").IsRequired();
            Property(x => x.TwoFactorEnabled).HasColumnName("TwoFactorEnabled").HasColumnType("bit").IsRequired();
            Property(x => x.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc").HasColumnType("datetime").IsOptional();
            Property(x => x.LockoutEnabled).HasColumnName("LockoutEnabled").HasColumnType("bit").IsRequired();
            Property(x => x.AccessFailedCount).HasColumnName("AccessFailedCount").HasColumnType("int").IsRequired();
            Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(x => x.LastName).HasColumnName("LastName").HasColumnType("nvarchar").IsOptional().HasMaxLength(50);
            Property(x => x.Title).HasColumnName("Title").HasColumnType("nvarchar").IsOptional().HasMaxLength(25);
            Property(x => x.CreatedTimestamp).HasColumnName("CreatedTimestamp").HasColumnType("datetime").IsRequired();
            Property(x => x.LastUpdatedTimestamp).HasColumnName("LastUpdatedTimestamp").HasColumnType("datetime").IsOptional();
            Property(x => x.Pending).HasColumnName("Pending").HasColumnType("bit").IsRequired();

            HasMany(x => x.Claims)
                .WithRequired()
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.Roles)
                .WithRequired()
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.Logins)
                .WithRequired()
                .HasForeignKey(x => x.UserId);
        }
    }
}