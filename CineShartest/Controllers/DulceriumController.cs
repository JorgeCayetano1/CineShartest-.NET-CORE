using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class DulceriumController : Controller
    {
        private readonly BDCineShartestContext _context;

        public DulceriumController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VDulceria()
        {
            IEnumerable<Dulcerium> ListDulcerium = _context.Dulceria;
            return View(ListDulcerium);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Dulcerium Dulcerium)
        {
            if (ModelState.IsValid)
            {
                _context.Dulceria.Add(Dulcerium);
                _context.SaveChanges();

                TempData["mensaje"] = "La Dulceria " + Dulcerium.IdDulc + " se ha creado correctamente";
                return RedirectToAction("VDulceria");
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
            var dulcerium = _context.Dulceria.Find(id);

            if (dulcerium == null)
            {
                return NotFound();
            }

            return View(dulcerium);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Dulcerium Dulcerium)
        {
            if (ModelState.IsValid)
            {
                _context.Dulceria.Update(Dulcerium);
                _context.SaveChanges();



                TempData["mensaje"] = "La Dulceria con ID " + Dulcerium.IdDulc + " se ha actualizado correctamente";
                return RedirectToAction("VDulceria");

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
            var dulcerium = _context.Dulceria.Find(id);

            if (dulcerium == null)
            {
                return NotFound();
            }

            return View(dulcerium);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteDulceria(int? id)
        {
            var dulcerium = _context.Dulceria.Find(id);

            if (dulcerium == null)
            {
                return NotFound();
            }

            _context.Dulceria.Remove(dulcerium);
            _context.SaveChanges();



            TempData["mensaje"] = "La Dulceria con ID " + dulcerium.IdDulc + " se ha eliminado correctamente";
            return RedirectToAction("VDulceria");
        }

    }
}
