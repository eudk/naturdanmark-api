using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace naturdanmark_api.Controllers
{
    public class ImagesController : Controller
    {
        // GET: ImagesController
        public ActionResult Post()
        {


            return View();
        }

        // GET: ImagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImagesController/Create
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

        // GET: ImagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImagesController/Edit/5
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

        // GET: ImagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImagesController/Delete/5
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
