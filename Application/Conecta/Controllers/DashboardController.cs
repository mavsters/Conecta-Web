using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conecta.Controllers
{
    [Authorize]
    public class DashboardController : LanguageController
    {



        // GET: Dashboard
        public ActionResult Index()
        {
            getNameUser();
            return View();
        }

        public ActionResult Eventos()
        {
            getNameUser();
            return View();
        }

        public ActionResult Historia()
        {
            getNameUser();
            return View();
        }
        public ActionResult Conecta()
        {
            getNameUser();
            return View();
        }
        public ActionResult App()
        {
            getNameUser();
            return View();
        }
        public ActionResult Instrucciones()
        {
            getNameUser();
            return View();
        }


        public void getNameUser()
        {

            if (User.Identity.IsAuthenticated)
            {
                ViewData["FullName"] = User.Identity.Name;
            }
            else
            {
                ViewData["FullName"] = "Home page for guest user.";
            }
        }


        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}