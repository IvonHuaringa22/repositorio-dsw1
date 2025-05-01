using Microsoft.AspNetCore.Mvc;
using Proyecto_DSWI_GP3.Data;
using Proyecto_DSWI_GP3.Models;
using BCrypt.Net;
using Microsoft.CodeAnalysis.Scripting;
using Proyecto_DSWI_GP3.Data.Contrato;

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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuarios modelo)
        {
            var usuarios = await _usuariosRepositorio.Listar(); // Espera la tarea
            var usuario = usuarios.FirstOrDefault(u => u.Correo == modelo.Correo);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(modelo.Contraseña, usuario.Contraseña))
            {
                if (usuario.TipoUsuario == "Administrador")
                    return RedirectToAction("Index", "PanelAdmin");
                else
                    return RedirectToAction("Index", "PanelCliente");
            }

            ViewBag.Mensaje = "Credenciales inválidas";
            return View();
        }
    }
}
