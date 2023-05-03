using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication2.Models;
using WebApplication2.Logica;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Index(string usuario , string clave)
        {
            Users obj = new LO_User().EncontrarUruario(usuario,clave);

            if (obj.Nombre != null )
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usuario),
                    new Claim(ClaimTypes.Role, obj.IdRol),
            };
                string currentRole = obj.IdRol;
                ViewBag.Currentrole = currentRole;
                var claimsIdentity = new ClaimsIdentity(claims, "Index");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(obj));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
