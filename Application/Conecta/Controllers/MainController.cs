using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Controllers
{
    public class MainController : LanguageController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MemoriaGrafica()
        {
            return View();
        }

        public IActionResult ProyectoBID()
        {
            return View();
        }

        public IActionResult Conecta()
        {
            return View();
        }

        public IActionResult Postulacion()
        {
            return View();
        }

        public IActionResult FaseUno()
        {
            return View();
        }

        public IActionResult FaseDos()
        {
            return View();
        }
        
            
    }
}