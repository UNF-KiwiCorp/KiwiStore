namespace KiwiCorp.Models {
	public interface IListingRepository {
		IEnumerable<Listing> Listings { get; }
	}
}
