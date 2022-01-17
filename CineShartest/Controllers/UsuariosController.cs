using CineShartest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineShartest.Controllers
{
    public class UsuariosController : Controller
    {
        public DBLogin1Context _context;
        public UsuariosController(DBLogin1Context master) {
            this._context = master;
        }
        [HttpPost]
        public IActionResult GetUsuarios(string NombreUsuario, string Clave)
        {
            var usuario = _context.UsuariosDbSet.Where(s => s.SuNick == NombreUsuario && s.SuPass == Clave);

            if (usuario.Any()) {

                if (usuario.Where(s => s.SuNick == NombreUsuario && s.SuPass == Clave).Any())
                {
                    return Json(new {status = true, message = "Bienvenido"});
                }
                else {
                    return Json(new { status = false, message = "Clave Incorrecta" });
                }
            }
            else {
                return Json(new { status = false, message = "Usuario Incorrecto" });
            }
        }
    }
}
