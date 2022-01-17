using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class ProductoController : Controller
    {
        private readonly BDCineShartestContext _context;

        public ProductoController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VProducto()
        {
            IEnumerable<Producto> ListProducto = _context.Productos;
            return View(ListProducto);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Producto Producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(Producto);
                _context.SaveChanges();

                TempData["mensaje"] = "El Producto " + Producto.IdProd + " se ha creado correctamente";
                return RedirectToAction("VProducto");
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
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Producto Producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(Producto);
                _context.SaveChanges();



                TempData["mensaje"] = "El Producto con ID " + Producto.IdProd + " se ha actualizado correctamente";
                return RedirectToAction("VProducto");

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
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteProducto(int? id)
        {
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            _context.SaveChanges();



            TempData["mensaje"] = "El Empleado con ID " + producto.IdProd + " se ha eliminado correctamente";
            return RedirectToAction("VProducto");
        }
    }
}
