using Microsoft.AspNetCore.Mvc;

namespace KuaforProjesi.Controllers{
    public class RandevuController:Controller 
    {
        public IActionResult Randevu()
        {
            return View();
        }
        
    } 
}