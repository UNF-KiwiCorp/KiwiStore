namespace KiwiCorpSite.Models
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Transactions { get; }

        public void NewTransaction(Account Buyer, Listing item);
        public void RefundTransaction(int id);
    }
}