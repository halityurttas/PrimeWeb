using Microsoft.AspNet.Identity.EntityFramework;
using PrimeWeb.Data.Domain;
using PrimeWeb.Data.Identity;
using System.Data.Entity;
using System.Reflection;

namespace PrimeWeb.Data
{
    public class DBContext : IdentityDbContext<User, Role, int, Login, UserRole, UserClaim>
    {

        public DBContext()
            :base("DefaultConnection")
        {
        }

        public DbSet<Content> Contents { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetCallingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public static DBContext Create()
        {
            return new DBContext();
        }
    }
}