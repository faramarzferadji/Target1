using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Target1.Models;
using Target1.Repository;
using Target1.Repository.IRepository;

namespace Target1.Controllers
{
    //[Authorize(Roles = SD.Role_Admin)]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IUnitofWork _dbu;
        public CustomerController(ILogger<CustomerController> logger, IUnitofWork dbu)
        {
            _logger = logger;
            _dbu = dbu;            
        }
        public CustomerService CustomerService { get; set; }
        public double Getmonthly(double Rate, double Loan, int Month, double Monthly)
        {

            Monthly = Math.Round((Loan) *
           (Rate / 12 * (Math.Pow((1 + (Rate / 12)), Month))) / (Math.Pow((1 + (Rate / 12)), Month) - 1));
            return Monthly;
        }
        public double GetCredit(double LimitLine, double Loan, double Credit)
        {
            Credit = LimitLine-Loan;
         
            return Credit;
        }
        public IActionResult Banking(Customer customer) 
        {
           
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            CustomerService = new CustomerService()
            {
                LstCart = _dbu.BankingCart3
                .GetAll(x => x.ApplicationUserId == clime.Value, includeProperties: "Banks"),
                Customer = new()
            };
            CustomerService.Customer.ApplicationUser = _dbu.applicationUser.GetFirstorDefult(x => x.Id == clime.Value);
            CustomerService.Customer.FirstName = CustomerService.Customer.ApplicationUser.FirstName;
            CustomerService.Customer.LastName = CustomerService.Customer.ApplicationUser.LastName;
            CustomerService.Customer.Email = CustomerService.Customer.ApplicationUser.Email;
            CustomerService.Customer.PhoneNumber = CustomerService.Customer.ApplicationUser.PhoneNumber;
            CustomerService.Customer.CodePostal = CustomerService.Customer.ApplicationUser.CodePostal;

            Banks banks = new Banks();

            foreach (var item in CustomerService.LstCart)
            {
               
                item.Monthy += Getmonthly(item.Banks.Rates, item.Loan, item.Month, item.Monthy);//Correct Method
                //item.Biweekly = Getbiweekly(item.Banks.Rates, item.Loan, item.Month, item.Biweekly);//Correct Method
                item.Biweekly += Math.Round(item.Monthy * 12 / 26);
                item.Credit += GetCredit(item.Banks.LimitLine, item.Loan, item.Credit);
                banks.BankName = item.Banks.BankName;
                banks.Rates = item.Banks.Rates;
                banks.LimitLine = (int)item.Credit;

                banks.Imagurl = item.Banks.Imagurl;
                _dbu.Banks.Update(banks);
                _dbu.Banks.Save();

            }
             
            TempData["success"] = "Add new item to Banking Cart is Successfully";
            return View(CustomerService);
        }
        public IActionResult DeleteObj(int CartId)
        {
            bool success = false; // result of your validation logic
            try
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
            var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            Banks banks = new Banks();
            CustomerService = new CustomerService()
            {
                LstCart = _dbu.BankingCart3
                .GetAll(x => x.ApplicationUserId == clime.Value, includeProperties: "Banks"),
                Customer = new()
            };
            foreach (var item in CustomerService.LstCart)
            {
                banks.BankName = item.Banks.BankName;
                banks.Rates = item.Banks.Rates;
                banks.LimitLine = (int)item.Credit;

                banks.Imagurl = item.Banks.Imagurl;
                CartId = item.BanksId;

            }
             var Cart = _dbu.Banks.GetFirstorDefult(x => x.Id == CartId);
            _dbu.Banks.Remove(Cart);
            _dbu.Banks.Save();
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
               
                ModelState.AddModelError("", "Unable to save changes." +
                    " Try again, and if the problem persists, see your system administrator.");
            }
            if (success)
                return Json(new { success = true });
            else
                return Json(new { success = false });
          

        }
     



        public IActionResult Remove(int cartId)
        {
            var cart = _dbu.BankingCart3.GetFirstorDefult(x => x.Id == cartId);
            _dbu.BankingCart3.Remove(cart);
            _dbu.Save();
            TempData["success"] = "Remove Successfully";
            return RedirectToAction("Banking");
        }
        //for add loan
        public IActionResult Plus(int cartId)
        {

            var cart = _dbu.BankingCart3.GetFirstorDefult(x => x.Id == cartId);
           
            _dbu.BankingCart3.IncrementCounts(cart, 100000);
            _dbu.Save();

            return RedirectToAction("Banking");
        }
        public IActionResult Minus(int cartId)
        {

            var cart = _dbu.BankingCart3.GetFirstorDefult(x => x.Id == cartId);

            _dbu.BankingCart3.DecrementCounts(cart, 100000);
            _dbu.Save();

            return RedirectToAction("Banking");
        }
       
      

        public IActionResult PlusM(int cartId)
        {

            var cart = _dbu.BankingCart3.GetFirstorDefult(x => x.Id == cartId);

            _dbu.BankingCart3.IncrementCount(cart, 6);
            _dbu.Save();

            return RedirectToAction("Banking");
        }
        public IActionResult MinusM(int cartId)
        {

            var cart = _dbu.BankingCart3.GetFirstorDefult(x => x.Id == cartId);

            _dbu.BankingCart3.DecrementCount(cart, 6);
            _dbu.Save();

            return RedirectToAction("Banking");
        }

        public IActionResult Ins_Customer(Customer customer)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            customer.ApplicationUser = _dbu.applicationUser.GetFirstorDefult(x => x.Id == clime.Value);
            customer.FirstName = customer.ApplicationUser.FirstName;
            customer.LastName = customer.ApplicationUser.LastName;
            customer.Email = customer.ApplicationUser.Email;
            customer.PhoneNumber = customer.ApplicationUser.PhoneNumber;
            customer.CodePostal = customer.ApplicationUser.CodePostal;
            _dbu.Customer.Add(customer);
            _dbu.Customer.Save();
            return View(customer);
        }
    }
}
