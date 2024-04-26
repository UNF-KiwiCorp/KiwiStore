namespace KiwiCorpSite.Models
{
    public class EFTransactionRepository : ITransactionRepository
    {
        ApplicationDbContext context;

        public EFTransactionRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<Transaction> Transactions => context.Transactions;

        public void RefundTransaction(int id)
        {
            Transaction dbEntry = context.Transactions.FirstOrDefault(x => x.Id == id);

            dbEntry.Refunded = true;
        }

        public void NewTransaction(Account Buyer, Account Seller) // add parameters for items/listings to get price and name
        {
            DateTime dateTime = DateTime.Now;
            string DateString = dateTime.ToString();
            Transaction newTransaction = new Transaction();

            newTransaction.Date = DateString;
            newTransaction.ItemPrice = 5;
            newTransaction.ItemName = "Missing Name";
            newTransaction.BuyerId = Buyer.Id;
            newTransaction.SellerId = Seller.Id;

            context.Transactions.Add(newTransaction);

        }
    }
}
