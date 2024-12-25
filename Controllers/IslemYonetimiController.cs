using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli


namespace KuaforProjesi.Controllers
{
    public class IslemYonetimiController : Controller
    {
        public IActionResult IslemYonetimi()
        {
            return View();
        }
    }
}
