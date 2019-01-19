using Eferada.Data.Model.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations.Identity
{
    public class ApplicationUserClaimConfiguration : EntityTypeConfiguration<ApplicationUserClaim>
    {
        public ApplicationUserClaimConfiguration() : this("dbo")
        {

        }

        public ApplicationUserClaimConfiguration(string schema)
        {
            ToTable("UserClaims", schema);
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.ClaimType)
                .HasColumnName("ClaimType")
                .HasColumnType("nvarchar(max)")
                .IsOptional();

            Property(x => x.ClaimValue)
                .HasColumnName("ClaimValue")
                .HasColumnType("nvarchar(max)")
                .IsOptional();

            HasRequired(x => x.User)
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.UserId);
        }
    }
}