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
            context.Listings.Add(newListing);
            context.SaveChanges();
        }

        public void EditListing(Listing newData)
        {
            Listing old = context.Listings.FirstOrDefault(a => a.ListingID == newData.ListingID);
            old = newData;
            context.SaveChanges();
        }
    }
}
