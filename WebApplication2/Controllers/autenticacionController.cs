using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "1")]
    public class autenticacionController : Controller
    {
        private readonly autenticacionContext _context;

        public autenticacionController(autenticacionContext context)
        {
            _context = context;
        }
        // GET autenticacion
        public async Task<IActionResult> Index(string searchString,string searchString1,string searchString2)
        {
            IQueryable<Users> items = from i in _context.users select i;
            ViewBag.CurrentFilter  = searchString;
            ViewBag.CurrentFilter1 = searchString1;
            ViewBag.CurrentFilter2 = searchString2;

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Region.Contains(searchString));
            }
            
            if (!String.IsNullOrEmpty(searchString1))
            {
                items = items.Where(s => s.Nombre.Contains(searchString1));
            }
            
            if (!String.IsNullOrEmpty(searchString2))
            {
                items = items.Where(s => s.IdRol == searchString2);
            }

            return View(await items.ToListAsync());
        }
        public IActionResult Create() => View();

        // Get: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Users item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();

                TempData["Succes"] = "Se ha agregado al usuario correctamente!";

                return RedirectToAction("Index");
            }
            return View(item);
        }

        // Get: Edit
        public async Task<IActionResult> Edit(int id)
        {
            Users item = await _context.users.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Users item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();

                TempData["Succes"] = "Se ha editado el usuario correctamente!";

                return RedirectToAction("Index");
            }
            return View(item);
        }

        // Get: Delete
        public async Task<IActionResult> Delete(int id)
        {
            Users item = await _context.users.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "El usuario no existe";
            }
            else
            {
                _context.users.Remove(item);
                await _context.SaveChangesAsync();

                TempData["Succes"] = "El usuario se ha eliminado correctamente!";
            }
            return RedirectToAction("Index");
        }
    }
}
