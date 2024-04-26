namespace KiwiCorpSite.Models {
	public class User {
		public int UserID { get; set; }

		public String FName { get; set; }
		public String MInitial { get; set; }
		public String LName { get; set; }

		public String Street { get; set; }
		public String City { get; set; }
		public String State { get; set; }
		public int ZipCode { get; set; }

		public String Email { get; set; }
	}
}
