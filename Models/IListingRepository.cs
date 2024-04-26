using System.Reflection;

namespace KiwiCorpSite.Models
{
    public interface IListingRepository
    {
        IEnumerable<Listing> Listings { get; }
    }
}