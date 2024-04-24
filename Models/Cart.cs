namespace KiwiCorp.Models {
	public class Cart {
		public String CustomerID { get; set; }

		public double SubTotal { get; set; }
		public double Tax { get; set; }
		public double Fees { get; set; }
		public double GrandTotal { get; set; }
	}
}
