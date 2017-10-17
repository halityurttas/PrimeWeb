using PrimeWeb.Data.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PrimeWeb.Data.Config
{
    internal class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.UserName).HasMaxLength(150).IsRequired();
        }
    }
}
