using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC23.Models;


namespace MVC23.Controllers
{
    public class ExtraController : Controller
    {
        private Contexto contexto;
        public ExtraController(Contexto contexto)
        {
            this.contexto = contexto;
        }
        // GET: ExtraController
        public ActionResult Index()
        {
            ViewBag.losExtras = contexto.Extras.ToList();
            return View();
        }

        // GET: ExtraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExtraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtraController/Create
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

        // GET: ExtraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExtraController/Edit/5
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

        // GET: ExtraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExtraController/Delete/5
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
