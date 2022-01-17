using CineShartest.Data;
using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class EmpleadoController : Controller
    {

        private readonly BDCineShartestContext _context;

        public EmpleadoController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VEmpleado()
        {
            IEnumerable<Empleado> ListEmpleado = _context.Empleados;
            return View(ListEmpleado);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Empleado Empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Add(Empleado);
                _context.SaveChanges();

                TempData["mensaje"] = "El Empleado " + Empleado.IdEmp + " se ha creado correctamente";
                return RedirectToAction("VEmpleado");
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
            var empleado = _context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Empleado Empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Update(Empleado);
                _context.SaveChanges();



                TempData["mensaje"] = "El Empleado con ID " + Empleado.IdEmp + " se ha actualizado correctamente";
                return RedirectToAction("VEmpleado");

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
            var empleado = _context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteEmpleado(int? id)
        {
            var empleado = _context.Empleados.Find(id);

            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            _context.SaveChanges();



            TempData["mensaje"] = "El Empleado con ID " + empleado.IdEmp + " se ha eliminado correctamente";
            return RedirectToAction("VEmpleado");
        }

    }
}
