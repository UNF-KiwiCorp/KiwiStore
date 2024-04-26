namespace KiwiCorpSite.Models
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Transactions { get; }

        public void NewTransaction(Account Buyer, Account Seller);
        public void RefundTransaction(int id);
    }
}