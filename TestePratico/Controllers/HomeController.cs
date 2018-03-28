using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestePratico.Models;
using TestePratico.Models.AccountViewModels;

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
