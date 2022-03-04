using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizesController : Controller
    {
        // GET: SizesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SizesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SizesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizesController/Create
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

        // GET: SizesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SizesController/Edit/5
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

        // GET: SizesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SizesController/Delete/5
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
