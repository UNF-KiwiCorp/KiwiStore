using KiwiCorpSite.Models;

namespace KiwiCorpSite.Models
{
    public class EFAccountRepository : IAccountRepository
    {
        private ApplicationDbContext context;
        public EFAccountRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Account> Accounts => context.Accounts;

        public void SaveAccount(Account account)
        {
            if (account.Id == 0)
            {
                context.Accounts.Add(account);
            }
            else
            {
                Account dbEntry = context.Accounts.FirstOrDefault(a => a.Id == account.Id);
                if (dbEntry != null)
                {


                    dbEntry.LegalName = account.LegalName;
                    dbEntry.UserName = account.UserName;
                    dbEntry.Email = account.Email;
                    dbEntry.cardNumber = account.cardNumber;
                    dbEntry.cvc = account.cvc;
                    dbEntry.expirationDate = account.expirationDate;
                }
            }
            context.SaveChanges();
        }
    }
}