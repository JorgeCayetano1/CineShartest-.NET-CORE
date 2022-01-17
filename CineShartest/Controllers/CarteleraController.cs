using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class CarteleraController : Controller
    {
        private readonly BDCineShartestContext _context;

        public CarteleraController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VCartelera()
        {
            IEnumerable<Cartelera> ListCartelera = _context.Carteleras;
            return View(ListCartelera);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Cartelera Cartelera)
        {
            if (ModelState.IsValid)
            {
                _context.Carteleras.Add(Cartelera);
                _context.SaveChanges();

                TempData["mensaje"] = "La Cartelera " + Cartelera.IdCartelera + " se ha creado correctamente";
                return RedirectToAction("VCartelera");
            }

            return View();
        }

        //Http GET getEdit
        public IActionResult getEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener Cliente
            var cartelera = _context.Carteleras.Find(id);

            if (cartelera == null)
            {
                return NotFound();
            }

            return View(cartelera);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Cartelera Cartelera)
        {
            if (ModelState.IsValid)
            {
                _context.Carteleras.Update(Cartelera);
                _context.SaveChanges();



                TempData["mensaje"] = "La Cartelera con ID " + Cartelera.IdCartelera + " se ha actualizado correctamente";
                return RedirectToAction("VCartelera");

            }

            return View();
        }

        //Http GET getDelete
        public IActionResult getDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener Cliente
            var cartelera = _context.Carteleras.Find(id);

            if (cartelera == null)
            {
                return NotFound();
            }

            return View(cartelera);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteCartelera(int? id)
        {
            var cartelera = _context.Carteleras.Find(id);

            if (cartelera == null)
            {
                return NotFound();
            }

            _context.Carteleras.Remove(cartelera);
            _context.SaveChanges();



            TempData["mensaje"] = "La Cartelera con ID " + cartelera.IdCartelera + " se ha eliminado correctamente";
            return RedirectToAction("VCartelera");
        }
    }
}
