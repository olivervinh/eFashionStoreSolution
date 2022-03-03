using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebApp.Areas.Admin.Controllers
{
    public class ColorsController : Controller
    {
        // GET: ColorsController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: ColorsController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColorsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ColorsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColorsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
