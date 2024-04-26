using KiwiCorpSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiwiCorpSite.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository repository;

        public static List<Listing> cart = new List<Listing>();

        public static Account ActiveAccount;
        public AccountController(IAccountRepository repo)
        {
            repository = repo;
        }
        
        public Account GetAccountById(int id) {
            foreach (Account acc in repository.Accounts) {
                if (acc.Id == id)
                {
                    return acc;
                }
            }
            return null;
        }

        public Account GetAccountByUsername(string username)
        {
            foreach (Account acc in repository.Accounts)
            {
                if (acc.Username == username)
                {
                    return acc;
                }
            }
            return null;
        }

        public ViewResult AddToCart(Listing listing) {
            cart.Add(listing);
            for (int i = 0; i < cart.Count; i++) {
                Console.WriteLine("Item {0} : {1} ", i, cart[i].Name);
            }
            return View("Browse");
        }

        public ViewResult AccountList() {
            return View(repository.Accounts);
        }

        public ViewResult AccountCreation() {
            return View();
        }

        public ViewResult AccountSettings(int id)
        {
            return View(GetAccountById(id));
        }


        [HttpPost]
        public IActionResult Edit(Account acc)
        {
            if (ModelState.IsValid)
            {
                repository.SaveAccount(acc);
                return View("AccountList", repository.Accounts);
            }
            else
            {
                // there is something wrong with the data values
                return View("AccountSettings",acc);
            }
        }

        public ViewResult SignIn(Account attempt) {
            Console.WriteLine(attempt.Username + ", " + attempt.Password);
            Account acc = GetAccountByUsername(attempt.Username);
            if (acc == null || acc.Password != attempt.Password) return View("LogInPage");
            else ActiveAccount = acc;
            Console.WriteLine(ActiveAccount.Username + " is the active account");
            return View("AccountList", repository.Accounts);
        }

        public ViewResult LogInPage() {
            return View();
        }

        [HttpPost]
        public ViewResult NewAccount(Account acc)
        {
            Random rand = new Random(System.DateTime.Now.Millisecond);
            acc.ReferalCode = rand.Next(100000000, 999999999).ToString();
            repository.SaveAccount(acc);
            return View("AccountList", repository.Accounts);
        }
    }
}
