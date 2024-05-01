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
            context.SaveChanges();
        }

        public void NewTransaction(Account Buyer, Listing item) // add parameters for items/listings to get price and name
        {
            DateTime dateTime = DateTime.Now;
            string DateString = dateTime.ToString();
            Transaction newTransaction = new Transaction();

            newTransaction.Date = DateString;
            newTransaction.ItemPrice = item.Price;
            newTransaction.ItemName = item.Name;
            newTransaction.BuyerId = Buyer.Id;
            newTransaction.SellerId = item.CustomerID;
            newTransaction.Refunded = false;

            context.Transactions.Add(newTransaction);

            context.SaveChanges();

        }
    }
}
