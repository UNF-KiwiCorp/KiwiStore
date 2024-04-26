using KiwiCorpSite.Models;

namespace KiwiCorpSite.Models {
	public class TestListingRepo : IListingRepository {
		public IEnumerable<Listing> Listings => new List<Listing> {
			new Listing {
							ListingID = 1,
							Name = "Monster Hunter 4 Ultimate, sealed copy", 
							Description = "A sealed copy of MH4U for 3DS. Never opened",
							Price = 110.00,
							Grade = 10
						},
			new Listing {
							ListingID = 2,
							Name = "The Orange Box, disk only", 
							Description = "i lost the box and instructions a long time ago. the disk still plays on my xbox",
							Price = 25.99
						},
			new Listing {
							ListingID = 3,
							Name = "Up (Pixar), blu-ray, minor scratches, still plays", 
							Description = "This is a hard to get physical copy of Up. There are some scratches on the disk, but I've watched the movie recently and can confirm it works fine. Comes with original box",
							Price = 30.95
						}
		};
	}
}