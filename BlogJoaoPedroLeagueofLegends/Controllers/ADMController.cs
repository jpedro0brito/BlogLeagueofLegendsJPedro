using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogJoaoPedroLeagueofLegends.Controllers
{
    public class ADMController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
    }
}