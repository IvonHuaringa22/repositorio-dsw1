using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_GP3.Data;
using Proyecto_DSWI_GP3.Models;
using BCrypt.Net;
using Microsoft.CodeAnalysis.Scripting;
using Proyecto_DSWI_GP3.Data.Contrato;
using Microsoft.AspNetCore.Http;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarios _usuariosRepositorio;

        public LoginController(IUsuarios usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol == "Administrador")
                return RedirectToAction("Index", "PanelAdmin");
            else if (rol == "Cliente")
                return RedirectToAction("Index", "PanelCliente");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuarios modelo)
        {
            var usuarios = await _usuariosRepositorio.Listar();
            var usuario = usuarios.FirstOrDefault(u => u.Correo == modelo.Correo);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(modelo.Contraseña, usuario.Contraseña))
            {
                // Guardar datos en sesión
                HttpContext.Session.SetString("Correo", usuario.Correo);
                HttpContext.Session.SetString("Rol", usuario.TipoUsuario);
                HttpContext.Session.SetString("Nombre", usuario.Nombre);

                if (usuario.TipoUsuario == "Administrador")
                    return RedirectToAction("Index", "PanelAdmin");
                else
                    return RedirectToAction("Index", "PanelCliente");
            }

            ViewBag.Mensaje = "Credenciales inválidas";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Cierra sesión
            return RedirectToAction("Login");
        }
    }
}
