using KiwiCorpSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace KiwiCorpSite.Controllers
{
    public class ListingController : Controller
    {
        private IListingRepository repo;
        private ITransactionRepository transactionRepository;

        public ListingController(IListingRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Listing(int ListingID)
        {
            Listing listing = GetListingById(ListingID);
            return View(listing);
        }

        public IActionResult Browse() {
            return View(repo.Listings);
        }

        public IActionResult CreateListing() {
            if (AccountController.ActiveAccount == null) return View("LogInPage");
            return View();
        }

        public ViewResult SubmitListing(Listing newListing) {
            repo.NewListing(newListing);
            return View("Browse", repo.Listings);
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