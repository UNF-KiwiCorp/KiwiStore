using Microsoft.EntityFrameworkCore;
using KiwiCorpSite.Models;

namespace KiwiCorpSite.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
        { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Listing>? Listings { get; set; }

    }
}