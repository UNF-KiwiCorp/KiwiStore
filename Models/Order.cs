namespace KiwiCorp.Models {
	public class Order {
		public String OrderID { get; set; }

		public double SubTotal { get; set; }
		public double Tax { get; set; }
		public double Fees { get; set; }
		public double GrandTotal { get; set; }
	}
}
