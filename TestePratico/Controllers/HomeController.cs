using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TestePratico.Models;
using TestePratico.Models.AccountViewModels;

namespace TestePratico.Controllers
{
    public class HomeController : Controller
    {
        //View disponível apenas para Admin
        public IActionResult Index()
        {
            return View();
        }
    }
}
