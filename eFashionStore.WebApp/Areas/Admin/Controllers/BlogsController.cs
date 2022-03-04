using eFashionStore.Service.Services.Catalogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private IBlogService _blogService;        
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        // GET: BlogsController
        public async Task<IActionResult> Index ([FromQuery(Name = "pageNumber")] int pageNumber, [FromQuery(Name = "pageSize")] int pageSize)
        {
            var blogsList = await _blogService.GetCustomBlogsPaginationListAsync(pageNumber, pageSize);
            return View(blogsList);
        }

        // GET: BlogsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogsController/Create
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

        // GET: BlogsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogsController/Edit/5
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

        // GET: BlogsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogsController/Delete/5
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
