using Microsoft.AspNetCore.Mvc;

namespace KuaforProjesi.Controllers{
    public class HomeController:Controller 
    {
        public IActionResult Index()
        {
            return View();
        }
        
    } 
}