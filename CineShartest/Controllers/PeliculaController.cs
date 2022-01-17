using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class PeliculaController : Controller
    {
        private readonly BDCineShartestContext _context;

        public PeliculaController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VPelicula()
        {
            IEnumerable<Pelicula> ListPelicula = _context.Peliculas;
            return View(ListPelicula);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Pelicula Pelicula)
        {
            if (ModelState.IsValid)
            {
                _context.Peliculas.Add(Pelicula);
                _context.SaveChanges();

                TempData["mensaje"] = "La Pelicula " + Pelicula.IdPeli + " se ha creado correctamente";
                return RedirectToAction("VPelicula");
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
            var pelicula = _context.Peliculas.Find(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Pelicula Pelicula)
        {
            if (ModelState.IsValid)
            {
                _context.Peliculas.Update(Pelicula);
                _context.SaveChanges();



                TempData["mensaje"] = "La Pelicula con ID " + Pelicula.IdPeli + " se ha actualizado correctamente";
                return RedirectToAction("VPelicula");

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
            var pelicula = _context.Peliculas.Find(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return View(pelicula);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeletePelicula(int? id)
        {
            var pelicula = _context.Peliculas.Find(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            _context.Peliculas.Remove(pelicula);
            _context.SaveChanges();



            TempData["mensaje"] = "La Pelicula con ID " + pelicula.IdPeli + " se ha eliminado correctamente";
            return RedirectToAction("VPelicula");
        }
    }
}
