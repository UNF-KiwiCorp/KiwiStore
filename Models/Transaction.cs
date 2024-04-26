namespace KiwiCorpSite.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }

        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string Date { get; set; }

        public bool Refunded { get; set; }
    }
}
