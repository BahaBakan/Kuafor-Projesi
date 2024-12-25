using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli
using Microsoft.AspNetCore.Authorization;

namespace KuaforProjesi.Controllers
{    
    [Authorize(Roles = "Admin")]
    public class AdminPaneliController : Controller
    {
        public IActionResult AdminPaneli()
        {
            return View();
        }
    }
}
