﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.lasMarcas = Contexto.Marcas.ToList();
            var lista = Contexto.Vehiculos.Include(v => v.Serie).ToList();
            return View(lista);
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(int id)
        {
            VeiculoModelo vehiculo = Contexto.Vehiculos.Include(v => v.Serie).FirstOrDefault(v => v.ID == id);
            return View(vehiculo);
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
        public ActionResult Listado(int Id)
        {
            ViewBag.lasMarcas = Contexto.Marcas.ToList();
            var lista = Contexto.Vehiculos.Include(v => v.Serie).ToList();
            return View(lista);
        }
        public ActionResult Listado2(int marcaID=1, int serieID=0)
        {
            ViewBag.lasMarcas = new SelectList(Contexto.Marcas, "ID", "Nom_marca", marcaID);
            ViewBag.lasSeries = new SelectList(Contexto.Series.Where(s => s.MarcaID == marcaID), "Id", "Nom_Serie", serieID);
            List<VeiculoModelo> vehiculos = Contexto.Vehiculos.Where(v => v.SerieID == serieID).ToList();
            return View(vehiculos);
        }
       
        // GET: VeiculoController/Busqueda/5
        public ActionResult Busqueda(string busca="")
        {
            ViewBag.buscar = busca;
            var lista =( from v in Contexto.Vehiculos
                        where (v.Matricula.Contains(busca))
                         select v).Include(v=>v.Serie).ToList();
            return View(lista);
        }
        // GET: VeiculoController/Busqueda2/5
        public ActionResult Busqueda2(string matricula = "")
        {
            ViewBag.matriculas = new SelectList(Contexto.Vehiculos, "Matricula", "Matricula",matricula);
            var lista = (from v in Contexto.Vehiculos
                         where (v.Matricula== matricula)
                         select v).Include(v => v.Serie).ToList();
            return View(lista);
        }
        // GET: VeiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SerieID = new SelectList(Contexto.Series, "ID", "Nom_serie");
            ViewBag.MarcaID = new SelectList(Contexto.Marcas, "ID", "Nom_marca");
            VeiculoModelo vehiculo = Contexto.Vehiculos.Find(id);
            return View(vehiculo);
        }
        

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VeiculoModelo vehiculoActualizado)
        {
            try
            {
                VeiculoModelo VehiculoActualizar = Contexto.Vehiculos.FirstOrDefault(v => v.ID == id);
                VehiculoActualizar.Matricula = vehiculoActualizado.Matricula;
                VehiculoActualizar.Color = vehiculoActualizado.Color;
                VehiculoActualizar.Serie.Marca = vehiculoActualizado.Serie.Marca;
                VehiculoActualizar.SerieID = vehiculoActualizado.SerieID;
                Contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VeiculoController/Delete/5
        public ActionResult Delete(VeiculoModelo vehiculo,int id)
        {
            VeiculoModelo VehiculoEliminar = Contexto.Vehiculos.FirstOrDefault(v => v.ID == id);
            return View(VehiculoEliminar);
        }

        // POST: VeiculoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                VeiculoModelo vehiculo = Contexto.Vehiculos.Find(id);
                Contexto.Vehiculos.Remove(vehiculo);
                Contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
