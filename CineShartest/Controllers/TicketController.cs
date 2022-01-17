using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class TicketController : Controller
    {
        private readonly BDCineShartestContext _context;

        public TicketController(BDCineShartestContext context)
        {
            _context = context;
        }

        public IActionResult VTicket()
        {
            IEnumerable<Ticket> ListTicket = _context.Tickets;
            return View(ListTicket);
        }

        public IActionResult getAdd()
        {
            return View();
        }

        //Https POST getAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getAdd(Ticket Ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(Ticket);
                _context.SaveChanges();

                TempData["mensaje"] = "El Ticket " + Ticket.IdTicket + " se ha creado correctamente";
                return RedirectToAction("VTicket");
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
            var ticket = _context.Tickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        //Https POST getEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult getEdit(Ticket Ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Update(Ticket);
                _context.SaveChanges();



                TempData["mensaje"] = "El Ticket con ID " + Ticket.IdTicket + " se ha actualizado correctamente";
                return RedirectToAction("VTicket");

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
            var ticket = _context.Tickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        //Https POST getDelete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult getDeleteTicket(int? id)
        {
            var ticket = _context.Tickets.Find(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();



            TempData["mensaje"] = "El Ticket con ID " + ticket.IdTicket + " se ha eliminado correctamente";
            return RedirectToAction("VTicket");
        }
    }
}
