using MenuTest.Domain;
using System.Data.Entity;

namespace MenuTest
{
    class MenuShellDbContext : DbContext
    {
        public MenuShellDbContext() : base("MenuShellDbContext")
        {               
        }

        public DbSet<User> Users { get; set; }
    }
}
