﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_DSWI_GP3.Data.Contrato;
using Proyecto_DSWI_GP3.Models;

namespace Proyecto_DSWI_GP3.Controllers
{
    public class UsuariosController : Controller
    {

        IUsuarios repoUsuarios;
        public UsuariosController(IUsuarios usuariosRepositorio)
        {
            repoUsuarios = usuariosRepositorio;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await repoUsuarios.Listar();
            return View(usuarios);
        }

        // GET: Usuarios/Details
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await repoUsuarios.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewBag.TiposUsuario = new SelectList(new List<string>
                {
                    "Administrador",
                    "Cliente"
                });
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                await repoUsuarios.Registrar(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await repoUsuarios.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewBag.TiposUsuario = new SelectList(new List<string>
                {
                    "Administrador",
                    "Cliente"
                });
            return View(usuario);
        }

        // POST: Usuarios/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
            {
                return NotFound();
            }

            await repoUsuarios.Actualizar(usuarios);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await repoUsuarios.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            await repoUsuarios.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
