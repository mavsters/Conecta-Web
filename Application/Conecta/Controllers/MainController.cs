﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Controllers
{
    public class MainController : Controller
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

        public IActionResult Actividades()
        {
            return View();
        }

    }
}