using KiwiCorpSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace KiwiCorpSite.Controllers
{
    public class ListingController : Controller
    {
        private IListingRepository repo;

        public ListingController(IListingRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Listing(int ListingID)
        {
            Listing listing = GetListingById(ListingID);
            return View(listing);
        }

        private Listing GetListingById(int ID)
        {
            Listing listing = null;
            foreach (Listing item in repo.Listings)
            {
                if (item.ListingID == ID)
                {
                    listing = item;
                }
            }
            return listing;
        }
    }
}