using System.Reflection;

namespace KiwiCorpSite.Models
{
    public interface IListingRepository
    {
        public IEnumerable<Listing> Listings { get; }

        public void NewListing(Listing newListing);

        public void EditListing(Listing newData);
    }
}