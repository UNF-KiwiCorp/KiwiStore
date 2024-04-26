namespace KiwiCorpSite.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string LegalName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string cardNumber { get; set; }
        public int cvc { get; set; }
        public string expirationDate { get; set; }


        public string? ReferalCode { get; set; }
        public string? AppliedReferal { get; set; }
    }
}
