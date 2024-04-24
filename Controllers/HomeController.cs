using KiwiCorp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KiwiCorp.Controllers {
	public class HomeController : Controller {
		//private readonly ILogger<HomeController> _logger;
		private IListingRepository repo;

		public HomeController(IListingRepository repo) {
			this.repo = repo;
		}

		//public ViewResult Index() => View(repo.Listings);

		
		public IActionResult Index() {
			return View(repo.Listings);
		}
		

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}