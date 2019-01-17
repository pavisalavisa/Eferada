using Eferada.Data.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Eferada.Data.EntityConfigurations
{
    public class NoticeConfiguration : EntityTypeConfiguration<Notice>
    {
        public NoticeConfiguration() : this("dbo")
        {

        }

        public NoticeConfiguration(string schema)
        {
            ToTable("Notice", schema);
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Content)
                .HasColumnName("Content")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(512);

            Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(64);

            Property(x => x.PublicationDateTime)
                .HasColumnName("PublicationDateTime")
                .HasColumnType("datetime")
                .IsRequired();

            HasRequired(x => x.NoticeCreator)
                .WithMany(x => x.Notices)
                .HasForeignKey(x => x.NoticeCreatorId);
        }
    }
}
