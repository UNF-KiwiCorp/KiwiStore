using KiwiCorpSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiwiCorpSite.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository repository;
        private ITransactionRepository transactionRepository;

        public static List<Listing> cart = new List<Listing>();

        public static Account ActiveAccount;
        public AccountController(IAccountRepository repo, ITransactionRepository transRepo)
        {
            repository = repo;
            transactionRepository = transRepo;
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

        public Account GetAccountByReferal(string referal) {
            foreach (Account acc in repository.Accounts) {
                if (acc.ReferalCode == referal) {
                    Console.WriteLine("Found account by referal");
                    return acc;
                }
            }
            Console.WriteLine("Failed to find account by referal");
            return null;
        }

        public ViewResult AddToCart(Listing listing) {
            cart.Add(listing);
            for (int i = 0; i < cart.Count; i++) {
                Console.WriteLine("Item {0} : {1} ", i, cart[i].Name);
            }
            return View("Cart", cart);
        }

        public ViewResult Checkout() {
            foreach (Listing item in cart) {
                transactionRepository.NewTransaction(ActiveAccount, item);
            }
            cart.Clear();

            // Check if the user has a referal applied that corresponds to a real user
            Account referee = ActiveAccount;
            if (referee.AppliedReferal != null && GetAccountByReferal(referee.AppliedReferal) != null) {
                // If the referal code corresponds to a real user, credit the referee $20 and the referer $30
                referee.CreditedFunds += 20;
                Account referer = GetAccountByReferal(referee.AppliedReferal);
                referer.CreditedFunds += 30;
                referee.AppliedReferal = null;
                repository.SaveAccount(referee);
                repository.SaveAccount(referer);
                Console.WriteLine("Referal complete");
            }

            return View("AccountList", repository.Accounts);
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
            return View("Index");
        }

        public ViewResult LogInPage() {
            return View();
        }

        [HttpPost]
        public ViewResult NewAccount(Account acc)
        {
            if (!ModelState.IsValid) return View("AccountCreation");
            Random rand = new Random(System.DateTime.Now.Millisecond);
            acc.ReferalCode = rand.Next(100000000, 999999999).ToString();
            repository.SaveAccount(acc);
            return View("AccountList", repository.Accounts);
        }

        public ViewResult Cart() {
            return View(cart);
            
        }

        public ViewResult TransactionHistory() {
            if (ActiveAccount == null) return View("LogInPage");
            return View(transactionRepository.Transactions);
        }

        public ViewResult Refund(int id) {
            transactionRepository.RefundTransaction(id);
            return View("TransactionHistory", transactionRepository.Transactions);
        }
    }
}
