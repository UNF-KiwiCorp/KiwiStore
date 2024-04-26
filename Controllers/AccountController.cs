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

        public ViewResult SignIn(Account acc) {
            ActiveAccount = acc;
            Console.WriteLine(ActiveAccount.UserName + " is the active account");
            return View("AccountList", repository.Accounts);
        }

        [HttpPost]
        public ViewResult NewAccount(Account acc)
        {
            repository.SaveAccount(acc);
            return View("AccountList", repository.Accounts);
        }
    }
}
