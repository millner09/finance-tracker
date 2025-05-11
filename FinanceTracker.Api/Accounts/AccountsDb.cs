using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.Accounts
{
    public class AccountsDb : DbContext
    {
        public AccountsDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
