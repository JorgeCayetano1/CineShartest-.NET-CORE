using CineShartest.Data;
using CineShartest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult VCliente()
        {
            IEnumerable<Cliente> ListCliente = _context.Cliente;
            return View(ListCliente);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Cliente Cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Cliente.Add(Cliente);
                _context.SaveChanges();

                TempData["mensaje"] = "El Cliente " + Cliente.ID_CLI + " se ha creado correctamente";
                return RedirectToAction("VCliente");
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
            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Cliente Cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Cliente.Update(Cliente);
                _context.SaveChanges();



                TempData["mensaje"] = "El Cliente con ID " + Cliente.ID_CLI + " se ha actualizado correctamente";
                return RedirectToAction("VCliente");

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
            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteCliente(int? id)
        {
            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();



            TempData["mensaje"] = "El Cliente con ID " + cliente.ID_CLI + " se ha eliminado correctamente";
            return RedirectToAction("VCliente");
        }
    }
}
