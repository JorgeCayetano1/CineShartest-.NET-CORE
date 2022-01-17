using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class VentaController : Controller
    {
        private readonly BDCineShartestContext _context;

        public VentaController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VVenta()
        {
            IEnumerable<Ventum> ListVenta = _context.Venta;
            return View(ListVenta);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Ventum Venta)
        {
            if (ModelState.IsValid)
            {
                _context.Venta.Add(Venta);
                _context.SaveChanges();

                TempData["mensaje"] = "La Venta " + Venta.IdVenta + " se ha creado correctamente";
                return RedirectToAction("VVenta");
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
            var venta = _context.Venta.Find(id);

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Ventum Venta)
        {
            if (ModelState.IsValid)
            {
                _context.Venta.Update(Venta);
                _context.SaveChanges();



                TempData["mensaje"] = "La Venta con ID " + Venta.IdVenta + " se ha actualizado correctamente";
                return RedirectToAction("VVenta");

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
            var venta = _context.Venta.Find(id);

            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteVenta(int? id)
        {
            var venta = _context.Venta.Find(id);

            if (venta == null)
            {
                return NotFound();
            }

            _context.Venta.Remove(venta);
            _context.SaveChanges();



            TempData["mensaje"] = "La Venta con ID " + venta.IdVenta + " se ha eliminado correctamente";
            return RedirectToAction("VVenta");
        }
    }
}
