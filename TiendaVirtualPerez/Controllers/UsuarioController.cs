using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtualPerez.Data;
using TiendaVirtualPerez.Models;
using TiendaVirtualPerez.Helpers;

namespace TiendaVirtualPerez.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly TiendaContext _context;

        public UsuarioController(TiendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var usuarios = _context.Usuarios
                .ToList();

            return View(usuarios);
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpPost]

        public IActionResult Create(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            usuario.Clave = HashHelper.ObtenerHash(usuario.Clave);
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var usuario = _context.Usuarios.Find(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            usuario.Clave = HashHelper.ObtenerHash(usuario.Clave);
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
