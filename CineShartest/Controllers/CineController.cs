using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class CineController : Controller
    {
        private readonly BDCineShartestContext _context;

        public CineController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VCine()
        {
            IEnumerable<Cine> ListCine = _context.Cines;
            return View(ListCine);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Cine Cine)
        {
            if (ModelState.IsValid)
            {
                _context.Cines.Add(Cine);
                _context.SaveChanges();

                TempData["mensaje"] = "El Cine " + Cine.IdCine + " se ha creado correctamente";
                return RedirectToAction("VCine");
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
            var cine = _context.Cines.Find(id);

            if (cine == null)
            {
                return NotFound();
            }

            return View(cine);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Cine Cine)
        {
            if (ModelState.IsValid)
            {
                _context.Cines.Update(Cine);
                _context.SaveChanges();



                TempData["mensaje"] = "El Cine con ID " + Cine.IdCine + " se ha actualizado correctamente";
                return RedirectToAction("VCine");

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
            var cine = _context.Cines.Find(id);

            if (cine == null)
            {
                return NotFound();
            }

            return View(cine);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteCine(int? id)
        {
            var cine = _context.Cines.Find(id);

            if (cine == null)
            {
                return NotFound();
            }

            _context.Cines.Remove(cine);
            _context.SaveChanges();



            TempData["mensaje"] = "El Cine con ID " + cine.IdCine + " se ha eliminado correctamente";
            return RedirectToAction("VCine");
        }
    }
}
