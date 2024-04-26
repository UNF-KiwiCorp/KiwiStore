using KiwiCorpSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiwiCorpSite.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository repository;
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

        public ViewResult SignIn(string Username, string Password) {
            Console.WriteLine(Username + ", " + Password);
            Account acc = GetAccountByUsername(Username);
            if (acc == null || acc.Password != Password) return View("LogInPage");
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
