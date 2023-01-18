using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC23.Models;

namespace MVC23.Controllers
{
    public class VeiculoController : Controller
    {
        private Contexto Contexto { get; }
        public VeiculoController(Contexto contexto)
        {
            this.Contexto = contexto;
        }
        // GET: VeiculoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VeiculoController/Create
        public ActionResult Create()
        {
            ViewBag.SerieID = new SelectList(Contexto.Series, "ID", "Nom_serie");
            return View();
        }

        // POST: VeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoModelo veichulo)
        {
            try
            {
                Contexto.Vehiculos.Add(veichulo);
                Contexto.SaveChanges();
                return RedirectToAction(nameof(Create));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: VeiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VeiculoController/Edit/5
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

        // GET: VeiculoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VeiculoController/Delete/5
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
