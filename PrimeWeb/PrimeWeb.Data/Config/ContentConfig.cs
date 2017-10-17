using PrimeWeb.Data.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrimeWeb.Data.Config
{
    internal class ContentConfig : EntityTypeConfiguration<Content>
    {
        public ContentConfig()
        {
            ToTable("Content");
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.PageDescription).HasMaxLength(160);
            Property(p => p.PageKeywords).HasMaxLength(250);
            Property(p => p.PageTitle).HasMaxLength(150);
            Property(p => p.SeoUrl).HasMaxLength(250);
            Property(p => p.Title).HasMaxLength(250).IsRequired();

            HasRequired(e => e.Author).WithMany(e => e.Contents).HasForeignKey(k => k.AuthorId);
        }
    }
}
