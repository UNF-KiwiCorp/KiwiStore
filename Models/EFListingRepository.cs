using Microsoft.Build.Framework;

namespace KiwiCorpSite.Models
{
    public class EFListingRepository : IListingRepository
    {
        private ApplicationDbContext context;
        public IEnumerable<Listing> Listings => context.Listings;

        public EFListingRepository(ApplicationDbContext dbContext) {
            context = dbContext;
        }
        

        public void NewListing(Listing newListing) {
            newListing.Sold = false;
            context.Listings.Add(newListing);
            context.SaveChanges();
        }

        public void EditListing(Listing newData) {
            Listing old = context.Listings.FirstOrDefault(a => a.ListingID == newData.ListingID);
            old = newData;
            context.SaveChanges();
        }

        public void SellItem(Listing item) {
            Listing old = context.Listings.FirstOrDefault(a => a.ListingID == item.ListingID);
            old.Sold = true;
            context.SaveChanges();
        }
    }
}
