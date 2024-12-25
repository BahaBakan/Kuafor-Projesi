using KuaforProjesi.Data;
using Microsoft.AspNetCore.Mvc;

namespace KuaforProjesi.Controllers
{
    public class CalisanlarimizController : Controller
{    
        private readonly DataContext _context;  

         public CalisanlarimizController(DataContext context)
        {
            _context = context;
        }
    public IActionResult Calisanlarimiz()
    {  
           var calisanlar = _context.Calisanlarimiz.ToList();
            return View(calisanlar);
        
    }   

     [HttpPost]
        public IActionResult Ekle(Calisanlarimiz yeniCalisan)
        {
            if (ModelState.IsValid)
            {
                _context.Calisanlarimiz.Add(yeniCalisan);
                _context.SaveChanges();
                return RedirectToAction("Calisanlarimiz");
            }

            return View("Calisanlarimiz", _context.Calisanlarimiz.ToList());
        }
}
}