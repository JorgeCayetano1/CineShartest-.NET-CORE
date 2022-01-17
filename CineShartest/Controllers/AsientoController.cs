using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class AsientoController : Controller
    {
        private readonly BDCineShartestContext _context;

        public AsientoController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VAsiento()
        {
            IEnumerable<Asiento> ListAsiento = _context.Asientos;
            return View(ListAsiento);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Asiento Asiento)
        {
            if (ModelState.IsValid)
            {
                _context.Asientos.Add(Asiento);
                _context.SaveChanges();

                TempData["mensaje"] = "El Asiento " + Asiento.IdAsie + " se ha creado correctamente";
                return RedirectToAction("VAsiento");
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
            var asiento = _context.Asientos.Find(id);

            if (asiento == null)
            {
                return NotFound();
            }

            return View(asiento);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Asiento Asiento)
        {
            if (ModelState.IsValid)
            {
                _context.Asientos.Update(Asiento);
                _context.SaveChanges();



                TempData["mensaje"] = "El Asiento con ID " + Asiento.IdAsie + " se ha actualizado correctamente";
                return RedirectToAction("VAsiento");

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
            var asiento = _context.Asientos.Find(id);

            if (asiento == null)
            {
                return NotFound();
            }

            return View(asiento);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteAsiento(int? id)
        {
            var asiento = _context.Asientos.Find(id);

            if (asiento == null)
            {
                return NotFound();
            }

            _context.Asientos.Remove(asiento);
            _context.SaveChanges();



            TempData["mensaje"] = "El Asiento con ID " + asiento.IdAsie + " se ha eliminado correctamente";
            return RedirectToAction("VAsiento");
        }
    }
}
