using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using System.Data.SqlClient;

namespace WebApplication2.Controllers
{
    public class BdListController : Controller
    {
        private readonly PruebaSQLContext _context;

        public BdListController(PruebaSQLContext context)
        {
            _context = context;
        }
        public IActionResult Index(Mixmodel mixmodel)
        {
            List<IQueryable> Tables = new List<IQueryable>();
            IQueryable<BdAccidentes> items =  from i in _context.BdAccidentes select i;
            IQueryable<BdBajasPt> items1 = from i in _context.BdBajasPt select i;
            Tables.Add(items);
            Tables.Add(items1);
            Console.WriteLine(Tables);
            return View(Tables[0]);
        }

        // Get: Edit
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Edit([Bind("BDAccidente,BDBajasPt,BDBarredura" +
            ",BdCapUtilizada,BDCuadroBásico,BdDesperdiciosEmpaque,BdDesperdiciosTotale,BdEficaci" +
            ",BdPesoProducidoPesoPagado,BdProductividadLaboral,BdToneladasProducida,BdValorDeLaProducción,BdVariaciónDeLaOrden")] Mixmodel mixmodel, Edit ed)
        {
            return View(ed);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Edit(Edit ed)
        {
            var ofecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            TrDates oTrdate = _context.TrDates.Where(x => x.Fecha == ofecha).Single();
            var year = oTrdate.Week.Substring(oTrdate.Week.Length - 2, 2);
            // Crear una instancia de la clase SqlConnection
            var ind = ed.Indicador;
            var ind_pl = ed.Indicador_pl;
            SqlConnection conn = new SqlConnection("server=(localdb)\\Servidor; database = PruebaSQL; integrated security=True;");

            // Crear un objeto SqlCommand para realizar la actualización       
            if ( ed.Valor == null)
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE ['BD-" + ind_pl + "$'] SET " + ind_pl.Substring(0, ind_pl.Length - 10) + "_pl" + " = @nuevo_valor_pl WHERE Week = @Week_pl AND Region = @Region_pl AND Línea = @Linea", conn);
                cmd1.Parameters.AddWithValue("@nuevo_valor_pl", ed.Valor_pl);
                cmd1.Parameters.AddWithValue("@Week_pl", "Semana" + ed.Week + " " + year);
                cmd1.Parameters.AddWithValue("@Region_pl", ed.Region);
                cmd1.Parameters.AddWithValue("@Linea", ed.linea);
                conn.Open();
                // Ejecutar la consulta de actualización
                ViewData["message"] = $"Se han cargado correctamente los datos";
                int rowsAffected = cmd1.ExecuteNonQuery();
            }
            else if(ed.Valor_pl == null)
            {
                SqlCommand cmd = new SqlCommand("UPDATE ['BD-" + ind + "$'] SET [" + ind + "] = @nuevo_valor WHERE Week = @Week AND Region = @Region", conn);
                cmd.Parameters.AddWithValue("@nuevo_valor", ed.Valor);
                cmd.Parameters.AddWithValue("@Week", "Semana" + ed.Week + " " + year);
                cmd.Parameters.AddWithValue("@Region", ed.Region);
                Console.WriteLine(cmd.CommandText.ToString());
                conn.Open();
                ViewData["message"] = $"Se han cargado correctamente los datos";
                // Ejecutar la consulta de actualización
                int rowsAffected = cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE ['BD-" + ind_pl + "$'] SET " + ind_pl.Substring(0, ind_pl.Length - 10) + "_pl" + " = @nuevo_valor_pl WHERE Week = @Week_pl AND Region = @Region_pl AND Línea = @Linea", conn);
                cmd1.Parameters.AddWithValue("@nuevo_valor_pl", ed.Valor_pl);
                cmd1.Parameters.AddWithValue("@Week_pl", "Semana" + ed.Week + " " + year);
                cmd1.Parameters.AddWithValue("@Region_pl", ed.Region);
                cmd1.Parameters.AddWithValue("@Linea", ed.linea);
                conn.Open();
                // Ejecutar la consulta de actualización
                int rowsAffected = cmd1.ExecuteNonQuery();
                conn.Close();
                SqlCommand cmd = new SqlCommand("UPDATE ['BD-" + ind + "$'] SET [" + ind + "] = @nuevo_valor WHERE Week = @Week AND Region = @Region", conn);
                cmd.Parameters.AddWithValue("@nuevo_valor", ed.Valor);
                cmd.Parameters.AddWithValue("@Week", "Semana" + ed.Week + " " + year);
                cmd.Parameters.AddWithValue("@Region", ed.Region);
                Console.WriteLine(cmd.CommandText.ToString());
                conn.Open();
                // Ejecutar la consulta de actualización
                ViewData["message"] = $"Se han cargado correctamente los datos";
                int rowsAffected1 = cmd.ExecuteNonQuery();
            }
            conn.Close();
            return View(ed);
        }
    }
}
