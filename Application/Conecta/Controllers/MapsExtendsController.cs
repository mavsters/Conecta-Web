using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Controllers
{
    public class MapsExtendsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Recomendacion()
        {
            return View();
        }

        public IActionResult Fullscreen()
        {
            return View();
        }
    }
}