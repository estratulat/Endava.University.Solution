using Endava.University.Solution.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Endava.University.Solution.Repository
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) : base(options) {   }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        // When updating database run in Package Manager Console:
        //>Add-Migration <migration name>
        //>Update-Database
    }
}
