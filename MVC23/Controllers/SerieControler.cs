﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC23.Models;

namespace MVC23.Controllers
{
    public class SerieControler : Controller
    {
        private Contexto Contexto { get; }
        public SerieControler(Contexto contexto)
        {
            this.Contexto = contexto;
        }
   
        // GET: SerieControler
        public ActionResult Index()
        {
            var lista = Contexto.Series.Include(s =>s.Marca).ToList();
            return View(lista);
        }

        // GET: SerieControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SerieControler/Create
        public ActionResult Create()
        {
            ViewBag.MarcaID = new SelectList(Contexto.Series, "ID", "Nom_serie");
            return View();
        }

        // POST: SerieControler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SerieModelo serie)
        {
            try
            {
                Contexto.Series.Add(serie);
                Contexto.SaveChanges();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: SerieControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SerieControler/Edit/5
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

        // GET: SerieControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SerieControler/Delete/5
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
