namespace KiwiCorpSite.Models
{
    public class Listing
    {
        public int ListingID { get; set; }
		public int CustomerID { get; set; }

		public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public int Grade { get; set; }
    }
}