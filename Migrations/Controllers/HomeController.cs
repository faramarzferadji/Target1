using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Diagnostics;
using System.Security.Claims;
using System.Xml.Linq;
using Target1.Models;
using Target1.Repository.IRepository;

namespace Target1.Controllers
{
    
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUnitofWork _dbu;
        public HomeController(ILogger<HomeController> logger, IUnitofWork dbu)
        {
            _logger = logger;
            _dbu = dbu;
        }




        public IActionResult IndexBanks()
        {
            IEnumerable<Banks> Product = _dbu.Banks.GetAll();


            return View(Product);

        }

            

    



            public IActionResult Details2(int BanksId)
            {
            Banks banks= new Banks();
                BankingCart3 cart = new()
                {
                    
                    Month = 1,
                    Loan = 10000,

                    BanksId = BanksId,

                    Banks = _dbu.Banks.GetFirstorDefult(x => x.Id == BanksId),

                };
                return View(cart);

            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            [Authorize]
            public IActionResult Details2(BankingCart3 bankcart)

            {
                bool success = false; // result of your validation logic

                try
                {
                    var claimsIdentity = (ClaimsIdentity)User.Identity;
                    var clime = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                    bankcart.ApplicationUserId = clime.Value;

                    BankingCart3 cartDb = _dbu.BankingCart3.GetFirstorDefult(
                        x => x.ApplicationUserId == clime.Value && x.BanksId == bankcart.BanksId);
                if (cartDb == null)
                    _dbu.BankingCart3.Add(bankcart);
                else
                    //_dbu.BankingCart3.IncrementCount(cartDb, bankcart.Month);
                    _dbu.BankingCart3.IncrementCounts(cartDb, bankcart.Loan);
                   



                _dbu.Save();
                    success = true;
                }



                catch (Exception ex)
                {
                    success = false;
                    //Log the error(uncomment dex variable name and add a line here to write a log.)
                    ModelState.AddModelError("", "Unable to save changes." +
                        " Try again, and if the problem persists, see your system administrator.");
                }

                if (success)
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
               
            }



            public IActionResult Privacy()
            {
                return View();
            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            void calcul()
            {
                Banks pr = new();
                BankingCart3 bankingCart = new();
                var newLine = ((_dbu.Banks.GetFirstorDefult(x => x.LimitLine == pr.LimitLine))/*-(_dbu.BankingCart3.GetFirstorDefult(x => x.Loan == bankingCart.Loan))*/);
                //var newLine2 = _dbu.BankingCart3.GetFirstorDefult(x => x.Loan==bankingCart.Loan);
                //pr.LimitLine = newLine - newLine2;
                _dbu.Banks.Update(newLine);
                _dbu.Save();


            }
    }
}

