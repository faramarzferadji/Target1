using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Target1.Models;
using Target1.Repository.IRepository;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;


namespace Target1.Controllers
{
    //[Authorize(Roles =SD.Role_Admin)]
    public class BanksController : Controller
    {
        private readonly IUnitofWork _dbu;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BanksController(IUnitofWork dbu, IWebHostEnvironment hostEnvironment)


        {
            _dbu = dbu;
            _hostEnvironment = hostEnvironment;

        }
        [HttpGet]
        public IActionResult Indexx()

        {

            var objprolist = _dbu.Banks.GetAll();


            return View(objprolist);
        }
        public IActionResult Plus(int? Id)
        {

            var ProfromDbFirst = _dbu.Banks.GetFirstorDefult(x => x.Id == Id);


            return View(ProfromDbFirst);
        }
        [HttpPost, ActionName("Plus")]
        [ValidateAntiForgeryToken]
        public IActionResult PlusAction(int? Id)
        {

            var cart = _dbu.Banks.GetFirstorDefult(x => x.Id == Id);
            _dbu.Banks.IncrementLimit(cart, ((cart.LimitLine)*1/10));

            _dbu.Banks.Save();

            return RedirectToAction("Indexx");
        }
        public IActionResult Plus1(int? id)
        {
            Banks banks = new Banks();
            banks = _dbu.Banks.GetFirstorDefult(x => x.Id == id);
            return View(banks);
        }
        [HttpPost, ActionName("Plus1")]
        [ValidateAntiForgeryToken]
        public IActionResult PlusAction1(Banks banks)//just for update seprate from upsert.
        {
            if (banks.Id != 0)
            {
                _dbu.Banks.Update(banks);
            }



            _dbu.Banks.Save();

            return RedirectToAction("Indexx");
        }





        public IActionResult Upsert11(int? id)
        {

            Banks banks = new();


            if (id == null || id == 0)
            {


                return View(banks);

            }
            else
            {
                //Update Product


                banks = _dbu.Banks.GetFirstorDefult(x => x.Id == id);
                return View(banks);
            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert11(Banks banks, IFormFile? file)


        {

          

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    
                    string fileName = Guid.NewGuid().ToString();
                    var uploud = Path.Combine(wwwRootPath, @"Images\Products");
                    var extention = Path.GetExtension(file.FileName);
                    if (banks.Imagurl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, banks.Imagurl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);

                        }

                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploud, fileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    banks.Imagurl = @"\Images\Products\" + fileName + extention;

                }
                if (banks.Id == 0)
                {
                    _dbu.Banks.Add(banks);

                    TempData["successupsert"] = "Product Enter successfully";
                }
                else
                {
                    _dbu.Banks.Update(banks);
                    TempData["success"] = "Product Update successfully";
                }

                _dbu.Save();
                //TempData["success"] = "Product Update successfully";
                //TempData["successupsert"] = "Product Enter successfully";
                return RedirectToAction("Indexx");
            }


            return View(banks);
        }
        
        public IActionResult Delete(int? id)
        {

            var ProfromDbFirst = _dbu.Banks.GetFirstorDefult(x => x.Id == id);


            return View(ProfromDbFirst);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAction(int? id)
        {
            var ProFordb = _dbu.Banks.GetFirstorDefult(x => x.Id == id);
            _dbu.Banks.Remove(ProFordb);
            _dbu.Banks.Save();
            //calcul();
            //TempData["success"] = "deleted successfully";


            return RedirectToAction("Indexx");
        }
        public IActionResult Detaile(int? id)
        {

            var ProfromDb = _dbu.Banks.GetFirstorDefult(x => x.Id == id);


            return View(ProfromDb);
        }
        //For Example
       

    }
}
