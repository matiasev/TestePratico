using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestePratico.Controllers
{
    public class HomeController : Controller
    {
        //View disponível apenas para Admin
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
